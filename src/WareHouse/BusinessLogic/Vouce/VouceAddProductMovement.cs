#nullable enable
namespace LasMarias.WareHouse.BusinessLogic.Vouce;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Serilog;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Orun;
using Orun.Plugins;
using Orun.Extensions;
using LasMarias.WareHouse.Domain.DataModels.Vouce;
using LasMarias.WareHouse.Domain.Models;
using LasMarias.WareHouse.Domain.Repositories;

public class VouceAddProductMovement : 
    IAsyncMiddleware<VouceAddProductMovementInputModel, Domain.Models.Vouce>, IMiddlewarePlugin
{
    private IServiceScope? _scope;
    
    private IVouceRepository? _repository;

    private IProductRepository? _prodRepository;

    private IVendorRepository? _vendorRepository;

    private IChainOfResponsibility _chain;

    public string Name { get; set; } 

    public string Version { get; set; } 

    public string Author { get; set; } 

    public string Description { get; set; } 

    public string EventCode { get; set; } 

    public Guid PluginId { get; set; } 

    public string ShortName { get; set; } 

    public bool Enable { get; set; } 

    public int Level { get; set; }

    public ICollection<Dependency>? Dependencies { get; set; }

    public VouceAddProductMovement(IChainOfResponsibility chain)
    {
        Name = "WareHouse Vouce Add Product Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations";
        Description = "Add a new product to an existing vouce";
        ShortName = "WareHouse Vouce Create";
        Enable = true;
        Level = 0; // this MUST be the first plugn to execute
        Dependencies = new List<Dependency>();
        EventCode = "vouce-add-product-movement";
        _chain = chain.IsNullOrEmpty(nameof(chain));
    }

    public WebApplication? Configure(WebApplication builder)
    {
        _scope = builder.Services.CreateScope();
        return builder;
    }
        
    public IServiceCollection? ConfigureServices(IServiceCollection services)
    {
        return services;
    }

    public async Task<Domain.Models.Vouce> Run(VouceAddProductMovementInputModel parameter, 
        Func<VouceAddProductMovementInputModel, Task<Domain.Models.Vouce>> next)
    {
        try
        {
            Vouce result;
            
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");

            _repository = (IVouceRepository)_scope?.ServiceProvider.GetService<IVouceRepository>();
            _prodRepository = (IProductRepository)_scope?.ServiceProvider.GetService<IProductRepository>();
            _vendorRepository = (IVendorRepository)_scope?.ServiceProvider.GetService<IVendorRepository>();

            if(_repository == null)
            {
                throw new NullReferenceException($"Repository could not be null");
            }

            // execute the chain and get result
            result = await next(parameter);
            
            // look if some middleware has alreay generate the entity and insert it into the
            // database, otherwise create it and save changes.
            if(result == null)
            {    
                var applicationUserId = parameter.ApplicationUserId.IsNullOrEmpty("Application User Id could not be null");
                var note = parameter.Note.ThenIfNulltOrEmpty("");
                var movType = parameter.MovementType.Value.ThenIfNullOrEmpty(MovementType.NotDefined);
                var standType = parameter.StandType.Value.ThenIfNullOrEmpty(StandType.NotDefined);
                
                result = new Vouce
                {
                    applicationUserId = applicationUserId,
                    Note = note,
                    MovementType = movType,
                    StandType = standType
                };

                foreach(var movement in parameter.ProductMovements)
                {
                    var input = new ProductNewMovementInputModel
                    {
                        ApplicationUserId = applicationUserId,
                        MovementType = movType,
                        StandType = standType,
                        Amount = movement.Amount,
                        Price = movement.Price,
                        VendorId = movement.VendorId,
                        Description = movement.Description
                    };
                    // we use specialized business logic
                    var productMovement = await chain.ExecuteAsyncChain<ProductNewMovementInputModel, ProductMovement>(
                        "admin-product-new-movement", input
                    );

                    // TODO: check first if the product movement is for the same stand
                    result.ProductMovements.Add(productMovement);
                }
                await _repository.Create(result);
            }
            
            // no exception throw so we are ready to save entity
            await _repository.UnitOfWork.SaveAsync();

            // return the result of inserted data
            return await Task.FromResult(result);
        }
        catch (Exception ex)
        {
            Log.Error($"Exception running plugin {ShortName}: event {EventCode}: {ex.FullMessage()}");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }
}