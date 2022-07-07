#nullable enable
namespace LasMarias.WareHouse.BusinessLogic.MeasureUnit;

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
using LasMarias.WareHouse.Domain.DataModels.MeasureUnit;
using LasMarias.WareHouse.Domain.Models;
using LasMarias.WareHouse.Domain.Repositories;

public class MeasureUnitUpdate : 
    IAsyncMiddleware<MeasureUnitUpdateInputModel, Domain.Models.MeasureUnit>, IMiddlewarePlugin
{
    private IServiceScope? _scope;
    
    private IMeasureUnitRepository? _repository;

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

    public MeasureUnitUpdate()
    {
        Name = "WareHouse MeasureUnit Update Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations";
        Description = "returns a updated MeasureUnit";
        ShortName = "WareHouse MeasureUnit Update";
        Enable = true;
        Level = 0; // this MUST be the first plugn to execute
        Dependencies = new List<Dependency>();
        EventCode = "measure-unit-update";
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

    // >.Run(MeasureUnitUpdateInputModel, Func<MeasureUnitUpdateInputModel, Task<MeasureUnit>>)
    public async Task<Domain.Models.MeasureUnit> Run(MeasureUnitUpdateInputModel parameter, 
        Func<MeasureUnitUpdateInputModel, Task<Domain.Models.MeasureUnit>> next)
    {
        try
        {
            Domain.Models.MeasureUnit entity;
            
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");

            _repository = (IMeasureUnitRepository)_scope?.ServiceProvider.GetService<IMeasureUnitRepository>();
            if(_repository == null)
            {
                throw new NullReferenceException($"Repository could not be null");
            }
            
            if(!(await _repository.Any(x => x.MeasureUnitId == parameter.Id)))
            {
                throw new Exception($"MeasureUnit with id {parameter.Id} was not found");
            }

            // execute the chain and get entity
            entity = await next(parameter);
            
            // look if some middleware has alreay generate the entity and insert it into the
            // database, otherwise create it and save changes.
            if(entity == null)
            {    
                // map entry into a real entity
                var mappedEntity = _repository.Mapper.Map<Domain.Models.MeasureUnit>(parameter);
                entity = (Domain.Models.MeasureUnit)(await _repository.GetOne(x => x.MeasureUnitId == parameter.Id));

                if(entity == null)
                {
                    throw new Exception($"Attrbute with id {parameter.Id} was not found");
                }

                // map properties
                entity.Name = mappedEntity.Name.ThenIfNullOrEmpty(entity.Name);
                entity.Code = mappedEntity.Code.ThenIfNullOrEmpty(entity.Code);
                entity.Cast = mappedEntity.Cast.ThenIfNullOrEmpty(entity.Cast);

                await _repository.Update(entity.MeasureUnitId, entity);
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