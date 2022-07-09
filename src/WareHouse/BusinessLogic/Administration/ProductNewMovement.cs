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

    private IMovementRepository? _movementRepository;
    
    private IProductRepository? _prodRepository;

    private IVendorRepository? _vendorRepository;

    private IProductMovementRepository? _prodMovementRepository;

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

    public async Task<Domain.Models.ProductMovement> Run(ProductNewMovementInputModel parameter, 
        Func<ProductNewMovementInputModel, Task<Domain.Models.ProductMovement>> next)
    {
        try
        {
            Domain.Models.ProductMovement result;
            var movement = new Domain.Models.Movement();
            
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");

            _movementRepository = (IMovementRepository)_scope?.ServiceProvider.GetService<IMovementRepository>()!;
            _prodRepository = (IProductRepository)_scope?.ServiceProvider.GetService<IProductRepository>()!;
            _prodMovementRepository = (IProductMovementRepository)_scope?.ServiceProvider.GetService<IProductMovementRepository>()!;

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
                if(parameter.ApplicationUserId == null)
                {
                    throw new Exception("WareHouse: Application User could not be null");
                }

                if(!(await _prodRepository.Any(x => x.ProductId == parameter.ProductId)))
                {
                    throw new Exception($"WareHouse: Product with id {parameter.ProductId} was not found");
                }


                if(parameter.VendorId.HasValue)
                {
                    _vendorRepository = (IVendorRepository)_scope?.ServiceProvider.GetService<IVendorRepository>()!;
                    if(!(await _vendorRepository.Any(x => x.VendorId == parameter.VendorId.Value)))
                    {
                        throw new Exception($"WareHouse : Vendor with id {parameter.VendorId.Value} was not found");
                    }
                    movement.VendorId = parameter.VendorId;
                }

                movement.Amount = parameter.Amount.ThenIfNullOrEmpty(0);
                movement.MovementType = parameter.MovementType.ThenIfNullOrEmpty(MovementType.DeliverToStand);
                movement.StandType = parameter.StandType.Value.ThenIfNullOrEmpty(StandType.NotSpecified);
                movement.ApplicationUserId = parameter.ApplicationUserId;
                movement.Price = parameter.Price;
                movement.Description = parameter.Description.Value.ThenIfNullOrEmpty("");
                
                movement = await _movementRepository.Create(movement);
                await _movementRepository.UnitOfWork.SaveAsync();
            }
            
            // register relation
            result = new ProductMovement
            {
                ProductId = parameter.ProductId,
                MovementId = movement.MovementId
            };
            await _prodMovementRepository.Create(result);
            await _prodMovementRepository.UnitOfWork.SaveAsync();

            // return the result of inserted data
            return await Task.FromResult(result!);
        }
        catch (Exception ex)
        {
            Log.Error($"Exception running plugin {ShortName}: event {EventCode}: {ex.FullMessage()}");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }
}