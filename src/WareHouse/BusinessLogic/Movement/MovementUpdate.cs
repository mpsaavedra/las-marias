#nullable enable
namespace LasMarias.WareHouse.BusinessLogic.Movement;

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
using LasMarias.WareHouse.Domain.DataModels.Movement;
using LasMarias.WareHouse.Domain.Models;
using LasMarias.WareHouse.Domain.Repositories;

public class MovementUpdate : 
    IAsyncMiddleware<MovementUpdateInputModel, Domain.Models.Movement>, IMiddlewarePlugin
{
    private IServiceScope? _scope;
    
    private IMovementRepository? _repository;

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

    public MovementUpdate()
    {
        Name = "WareHouse Movement Update Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations";
        Description = "returns a updated Movement";
        ShortName = "WareHouse Movement Update";
        Enable = true;
        Level = 0; // this MUST be the first plugn to execute
        Dependencies = new List<Dependency>();
        EventCode = "movement-update";
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

    // >.Run(MovementUpdateInputModel, Func<MovementUpdateInputModel, Task<Movement>>)
    public async Task<Domain.Models.Movement> Run(MovementUpdateInputModel parameter, 
        Func<MovementUpdateInputModel, Task<Domain.Models.Movement>> next)
    {
        try
        {
            Domain.Models.Movement entity;
            
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");

            _repository = (IMovementRepository)_scope?.ServiceProvider.GetService<IMovementRepository>();
            if(_repository == null)
            {
                throw new NullReferenceException($"Repository could not be null");
            }
            
            if(!(await _repository.Any(x => x.MovementId == parameter.Id)))
            {
                throw new Exception($"Movement with id {parameter.Id} was not found");
            }

            // execute the chain and get entity
            entity = await next(parameter);
            
            // look if some middleware has alreay generate the entity and insert it into the
            // database, otherwise create it and save changes.
            if(entity == null)
            {    
                // map entry into a real entity
                var mappedEntity = _repository.Mapper.Map<Domain.Models.Movement>(parameter);
                entity = (Domain.Models.Movement)(await _repository.GetOne(x => x.MovementId == parameter.Id));

                if(entity == null)
                {
                    throw new Exception($"Attrbute with id {parameter.Id} was not found");
                }

                // map properties
                entity.Amount = mappedEntity.Amount.ThenIfNullOrEmpty(entity.Amount);
                entity.Price = mappedEntity.Price.ThenIfNullOrEmpty(entity.Price);
                entity.Description = mappedEntity.Description.ThenIfNullOrEmpty(entity.Description);
                entity.ApplicationUserId = mappedEntity.ApplicationUserId.ThenIfNullOrEmpty(entity.ApplicationUserId);
                entity.VendorId = mappedEntity.VendorId.ThenIfNullOrEmpty(entity.VendorId);
                entity.StandType = mappedEntity.StandType.ThenIfNullOrEmpty(entity.StandType);
                entity.MovementType = mappedEntity.MovementType.ThenIfNullOrEmpty(entity.MovementType);

                await _repository.Update(entity.MovementId, entity);
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