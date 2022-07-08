#nullable enable
namespace LasMarias.WareHouse.BusinessLogic.Administration;

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
using LasMarias.WareHouse.Domain.DataModels.Administration;
using LasMarias.WareHouse.Domain.Models;
using LasMarias.WareHouse.Domain.Repositories;

public class ProductNewMovement : 
    IAsyncMiddleware<ProductNewMovementInputModel, Domain.Models.ProductMovement>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private IProductMovementRepository? _repo;
    
    private IProductRepository? _prodRepository;

    private IVendorRepository? _vendorRepository;

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

    public ProductNewMovement()
    {
        Name = "WareHouse Product new movement Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations";
        Description = "register a new product movement in the system";
        ShortName = "WareHouse Product new movement";
        Enable = true;
        Level = 0; // this MUST be the first plugn to execute
        Dependencies = new List<Dependency>();
        EventCode = "admin-product-new-movement";
    }

    public WebApplication? Configure(WebApplication builder)
    {
        Log.Debug($"Configure plugin {ShortName}: event {EventCode}");
        _scope = builder.Services.CreateScope();
        return builder;
    }
        
    public IServiceCollection? ConfigureServices(IServiceCollection services)
    {
        Log.Debug($"Configure services for plugin {ShortName}: event {EventCode}");
        return services;
    }

    public async Task<Domain.Models.ProductMovement> Run(ProductNewMovementInputMovement parameter, 
        Func<ProductNewMovementInputModel, Task<Domain.Models.ProductMovement>> next)
    {
        try
        {
            Domain.Models.ProductMovement result;
            
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");

            _repo = (IProductMovementRepositoru)_scope?.ServiceProvider.GetService<IProductMovementRepository>();
            _prodRepository = (IProductRepository)_scope?.ServiceProvider.GetService<IProductRepository>();

            if(_prodRepository == null)
            {
                throw new NullReferenceException($"Repository could not be null");
            }

            // execute the chain and get result
            result = await next(parameter);
            
            // look if some middleware has alreay generate the entity and insert it into the
            // database, otherwise create it and save changes.
            if(result == null)
            {    
                result = new Domain.Models.ProductMovement();

                result.Amount = parameter.Amount.ThenIfNullOrEmpty(0);
                result.MovementType = parameter.MovementType.ThenIfNullOrEmpty(MovementType.DeliverToStand);
                result.ApplicationUserId = parameter.ApplicationUserId;
                result.Price = parameter.Price;

                if(!(await _prodRepository.Any(x => x.ProductId == parameter.ProductId)))
                {
                    throw new Exception($"WareHouse: Product with id {parameter.ProductId} was not found");
                }


                if(parameter.VendorId.HasValue())
                {
                    _vendorRepository = (IVendorRepository)_scope?.ServiceProvider.GetService<IVendorRepository>();
                    if(!(_vendorRepository.Any(x => x.VendorId == parameter.VendorId.Value)))
                    {
                        throw new Exception($"WareHouse : Vendor with id {parameter.VendorId.Value} was not found");
                    }
                    result.VendorId = parameter.VendorId;
                }
                
                
                result = await _repository.Create(result);
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