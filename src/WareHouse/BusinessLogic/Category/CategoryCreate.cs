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
using LasMarias.WareHouse.Domain.DataModels.Category;
using LasMarias.WareHouse.Domain.Models;
using LasMarias.WareHouse.Domain.Repositories;

public class CategoryCreate : 
    IAsyncMiddleware<CategoryCreateInputModel, Domain.Models.Category>, IMiddlewarePlugin
{
    private IServiceScope? _scope;
    
    private ICategoryRepository? _repository;

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

    public CategoryCreate()
    {
        Name = "WareHouse Category Create Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations";
        Description = "returns a new created Category";
        ShortName = "WareHouse Category Create";
        Enable = true;
        Level = 0; // this MUST be the first plugn to execute
        Dependencies = new List<Dependency>();
        EventCode = "category-create";
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

    public async Task<Domain.Models.Category> Run(CategoryCreateInputModel parameter, 
        Func<CategoryCreateInputModel, Task<Domain.Models.Category>> next)
    {
        try
        {
            Category result;
            
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");

            _repository = (ICategoryRepository)_scope?.ServiceProvider.GetService<ICategoryRepository>();
            if(_repository == null)
            {
                throw new NullReferenceException($"Repository could not be null");
            }

            // execute the chain and get result
            result = await next(parameter);
            
            // look if some middleware has alreay generate the entity and insert it into the
            // database, otherwise create it and save changes.
            if(result == null)
            {    
                // map entry into a real entity
                var mappedEntity = _repository.Mapper.Map<Category>(parameter);
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