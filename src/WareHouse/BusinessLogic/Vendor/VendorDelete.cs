#nullable enable
namespace LasMarias.WareHouse.BusinessLogic.Vendor;

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
using LasMarias.WareHouse.Domain.DataModels.Vendor;
using LasMarias.WareHouse.Domain.Models;
using LasMarias.WareHouse.Domain.Repositories;

public class VendorDelete : 
    IAsyncMiddleware<VendorDeleteInputModel, bool>, IMiddlewarePlugin
{
    private IServiceScope? _scope;
    
    private IVendorRepository? _repository;

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

    public VendorDelete()
    {
        Name = "WareHouse Vendor Delete Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations";
        Description = "deletes an existing Vendor";
        ShortName = "WareHouse Vendor Delete";
        Enable = true;
        Level = 0; // this MUST be the first plugn to execute
        Dependencies = new List<Dependency>();
        EventCode = "vendor-delete";
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

    public async Task<bool> Run(VendorDeleteInputModel parameter, 
        Func<VendorDeleteInputModel, Task<bool>> next)
    {
        try
        {
            var result = true;
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");

            _repository = (IVendorRepository)_scope?.ServiceProvider.GetService<IVendorRepository>();
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