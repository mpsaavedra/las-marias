#nullable enable
namespace LasMarias.WareHouse.BusinessLogic.ProdutBrand;

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
using LasMarias.WareHouse.Domain.DataModels.ProductBrand;
using LasMarias.WareHouse.Domain.Models;
using LasMarias.WareHouse.Domain.Repositories;

public class ProdutBrandList : IAsyncMiddleware<ProductBrandListPayload, bool>, IMiddlewarePlugin
{
    private IServiceScope? _scope;
    
    private IProductBrandRepository? _repository;

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

    public ProdutBrandList()
    {
        Name = "WareHouse Product ProdutBrand List Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations";
        Description = "returns a valid list with all available plugins ProdutBrands";
        ShortName = "WareHouse Product Brand List";
        Enable = true;
        Level = 0; // this MUST be the first plugn to execute
        Dependencies = new List<Dependency>();
        EventCode = "product-brand-list";
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

    public async Task<bool> Run(ProductBrandListPayload parameter, Func<ProductBrandListPayload, Task<bool>> next)
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
             _repository = _scope?.ServiceProvider.GetService<IProductBrandRepository>();
             if(_repository == null)
             {
                throw new NullReferenceException($"Repository could not be null");
             }
             parameter.Payload = await _repository?.Get(x => !x.Deleted);
             return await next(parameter);
        }
        catch (Exception ex)
        {
            Log.Error($"Exception running plugin {ShortName}: event {EventCode}: {ex.FullMessage()}");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }
}