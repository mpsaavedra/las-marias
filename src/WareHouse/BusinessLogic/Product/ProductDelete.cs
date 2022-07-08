#nullable enable
namespace LasMarias.WareHouse.BusinessLogic.Product;

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
using LasMarias.WareHouse.Domain.DataModels.Product;
using LasMarias.WareHouse.Domain.Models;
using LasMarias.WareHouse.Domain.Repositories;

public class ProductDelete : 
    IAsyncMiddleware<ProductDeleteInputModel, bool>, IMiddlewarePlugin
{
    private IServiceScope? _scope;
    
    private IProductRepository? _repository;

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

    public ProductDelete()
    {
        Name = "WareHouse Product Delete Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations";
        Description = "deletes an existing Product";
        ShortName = "WareHouse Product Delete";
        Enable = true;
        Level = 0; // this MUST be the first plugn to execute
        Dependencies = new List<Dependency>();
        EventCode = "product-delete";
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

    public async Task<bool> Run(ProductDeleteInputModel parameter, 
        Func<ProductDeleteInputModel, Task<bool>> next)
    {
        try
        {
            var result = true;
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");

            _repository = (IProductRepository)_scope?.ServiceProvider.GetService<IProductRepository>();
            if(_repository == null)
            {
                throw new NullReferenceException($"Repository could not be null");
            }

            var entity = await _repository.Get(parameter.Id);
            if(entity == null)
            {
                throw new Exception($"");
            }
            
            await next(parameter);
            
            await _repository.Delete(parameter.Id);
            await _repository.UnitOfWork.SaveAsync();

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