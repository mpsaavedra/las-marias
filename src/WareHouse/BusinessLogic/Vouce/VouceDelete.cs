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

public class VouceDelete : 
    IAsyncMiddleware<VouceDeleteInputModel, bool>, IMiddlewarePlugin
{
    private IServiceScope? _scope;
    
    private IVouceRepository? _repository;

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

    public VouceDelete()
    {
        Name = "WareHouse Vouce Delete Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations";
        Description = "deletes an existing Vouce";
        ShortName = "WareHouse Vouce Delete";
        Enable = true;
        Level = 0; // this MUST be the first plugn to execute
        Dependencies = new List<Dependency>();
        EventCode = "vouce-delete";
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

    public async Task<bool> Run(VouceDeleteInputModel parameter, 
        Func<VouceDeleteInputModel, Task<bool>> next)
    {
        try
        {
            var result = true;
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");

            _repository = (IVouceRepository)_scope?.ServiceProvider.GetService<IVouceRepository>();
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