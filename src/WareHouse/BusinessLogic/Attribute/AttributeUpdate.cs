#nullable enable
namespace LasMarias.WareHouse.BusinessLogic.Attribute;

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
using LasMarias.WareHouse.Domain.DataModels.Attribute;
using LasMarias.WareHouse.Domain.Models;
using LasMarias.WareHouse.Domain.Repositories;

public class AttributeUpdate : 
    IAsyncMiddleware<AttributeUpdateInputModel, Domain.Models.Attribute>, IMiddlewarePlugin
{
    private IServiceScope? _scope;
    
    private IAttributeRepository? _repository;

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

    public AttributeUpdate()
    {
        Name = "WareHouse Attribute Update Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations";
        Description = "returns a updated attribute";
        ShortName = "WareHouse Attribute Update";
        Enable = true;
        Level = 0; // this MUST be the first plugn to execute
        Dependencies = new List<Dependency>();
        EventCode = "attribute-update";
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

    // >.Run(AttributeUpdateInputModel, Func<AttributeUpdateInputModel, Task<Attribute>>)
    public async Task<Domain.Models.Attribute> Run(AttributeUpdateInputModel parameter, 
        Func<AttributeUpdateInputModel, Task<Domain.Models.Attribute>> next)
    {
        try
        {
            Domain.Models.Attribute entity;
            
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");

            _repository = (IAttributeRepository)_scope?.ServiceProvider.GetService<IAttributeRepository>();
            if(_repository == null)
            {
                throw new NullReferenceException($"Repository could not be null");
            }
            
            if(!(await _repository.Any(x => x.AttributeId == parameter.Id)))
            {
                throw new Exception($"Attribute with id {parameter.Id} was not found");
            }

            // execute the chain and get entity
            entity = await next(parameter);
            
            // look if some middleware has alreay generate the entity and insert it into the
            // database, otherwise create it and save changes.
            if(entity == null)
            {    
                // map entry into a real entity
                var mappedEntity = _repository.Mapper.Map<Domain.Models.Attribute>(parameter);
                entity = (Domain.Models.Attribute)(await _repository.GetOne(x => x.AttributeId == parameter.Id));

                if(entity == null)
                {
                    throw new Exception($"Attrbute with id {parameter.Id} was not found");
                }

                // map properties
                entity.Value = mappedEntity.Value.ThenIfNullOrEmpty(entity.Value);
                entity.Description = mappedEntity.Description.ThenIfNullOrEmpty(entity.Description);
                entity.MeasureUnitId = mappedEntity.MeasureUnitId.ThenIfNullOrEmpty(entity.MeasureUnitId);
                entity.AttributeNameId = mappedEntity.AttributeNameId.ThenIfNullOrEmpty(entity.AttributeNameId);

                await _repository.Update(entity.AttributeId, entity);
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