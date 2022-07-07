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

public class VendorUpdate : 
    IAsyncMiddleware<VendorUpdateInputModel, Domain.Models.Vendor>, IMiddlewarePlugin
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

    public VendorUpdate()
    {
        Name = "WareHouse Vendor Update Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations";
        Description = "returns a updated Vendor";
        ShortName = "WareHouse Vendor Update";
        Enable = true;
        Level = 0; // this MUST be the first plugn to execute
        Dependencies = new List<Dependency>();
        EventCode = "vendor-update";
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

    // >.Run(VendorUpdateInputModel, Func<VendorUpdateInputModel, Task<Vendor>>)
    public async Task<Domain.Models.Vendor> Run(VendorUpdateInputModel parameter, 
        Func<VendorUpdateInputModel, Task<Domain.Models.Vendor>> next)
    {
        try
        {
            Domain.Models.Vendor entity;
            
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");

            _repository = (IVendorRepository)_scope?.ServiceProvider.GetService<IVendorRepository>();
            if(_repository == null)
            {
                throw new NullReferenceException($"Repository could not be null");
            }
            
            if(!(await _repository.Any(x => x.VendorId == parameter.Id)))
            {
                throw new Exception($"Vendor with id {parameter.Id} was not found");
            }

            // execute the chain and get entity
            entity = await next(parameter);
            
            // look if some middleware has alreay generate the entity and insert it into the
            // database, otherwise create it and save changes.
            if(entity == null)
            {    
                // map entry into a real entity
                var mappedEntity = _repository.Mapper.Map<Domain.Models.Vendor>(parameter);
                entity = (Domain.Models.Vendor)(await _repository.GetOne(x => x.VendorId == parameter.Id));

                if(entity == null)
                {
                    throw new Exception($"Attrbute with id {parameter.Id} was not found");
                }

                // map properties
                entity.Name = mappedEntity.Name.ThenIfNullOrEmpty(entity.Name);
                entity.Description = mappedEntity.Description.ThenIfNullOrEmpty(entity.Description);

                await _repository.Update(entity.VendorId, entity);
            }
            
            // no exception throw so we are ready to save entity
            await _repository.UnitOfWork.SaveAsync();

            // return the entity of inserted data
            return await Task.FromResult(entity);
        }
        catch (Exception ex)
        {
            Log.Error($"Exception running plugin {ShortName}: event {EventCode}: {ex.FullMessage()}");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }
}