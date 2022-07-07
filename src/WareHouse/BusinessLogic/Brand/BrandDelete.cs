#nullable enable
namespace LasMarias.WareHouse.BusinessLogic.Brand;

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
using LasMarias.WareHouse.Domain.DataModels.Brand;
using LasMarias.WareHouse.Domain.Models;
using LasMarias.WareHouse.Domain.Repositories;

public class BrandDelete : 
    IAsyncMiddleware<BrandDeleteInputModel, bool>, IMiddlewarePlugin
{
    private IServiceScope? _scope;
    
    private IBrandRepository? _repository;

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

    public BrandDelete()
    {
        Name = "WareHouse Brand Delete Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations";
        Description = "deletes an existing Brand";
        ShortName = "WareHouse Brand Delete";
        Enable = true;
        Level = 0; // this MUST be the first plugn to execute
        Dependencies = new List<Dependency>();
        EventCode = "brand-delete";
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

    public async Task<bool> Run(BrandDeleteInputModel parameter, 
        Func<BrandDeleteInputModel, Task<bool>> next)
    {
        try
        {
            var result = true;
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");

            _repository = (IBrandRepository)_scope?.ServiceProvider.GetService<IBrandRepository>();
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