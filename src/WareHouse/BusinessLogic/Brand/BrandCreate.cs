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

public class BrandCreate : 
    IAsyncMiddleware<BrandCreateInputModel, Domain.Models.Brand>, IMiddlewarePlugin
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

    public BrandCreate()
    {
        Name = "WareHouse Brand Create Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations";
        Description = "returns a new created Brand";
        ShortName = "WareHouse Brand Create";
        Enable = true;
        Level = 0; // this MUST be the first plugn to execute
        Dependencies = new List<Dependency>();
        EventCode = "brand-create";
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

    public async Task<Domain.Models.Brand> Run(BrandCreateInputModel parameter, 
        Func<BrandCreateInputModel, Task<Domain.Models.Brand>> next)
    {
        try
        {
            Brand result;
            
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");

            _repository = (IBrandRepository)_scope?.ServiceProvider.GetService<IBrandRepository>();
            if(_repository == null)
            {
                throw new NullReferenceException($"Repository could not be null");
            }

            // execute the chain and get result this is suppose to be the first middleware
            // to be executed and provide the last result
            result = await next(parameter);
            
            // look if some middleware has alreay generate the entity and insert it into the
            // database, otherwise create it and save changes.
            if(result == null)
            {    
                // map entry into a real entity
                var mappedEntity = _repository.Mapper.Map<Brand>(parameter);
                result = await _repository.Create(mappedEntity);
            }
            
            // no exception throw so we are ready to save entity
            await _repository.UnitOfWork.SaveAsync();

            // return the result of inserted data
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