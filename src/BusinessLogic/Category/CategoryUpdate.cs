namespace LasMarias.BusinessLogic.Category;

public class CategoryUpdate : IAsyncMiddleware<CategoryUpdateInputModel, Domain.Models.Category>, IMiddlewarePlugin
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

    public WebApplication? Configure(WebApplication builder)
    {
        _scope = builder.Services.CreateScope();
        return builder;
    }

    public IServiceCollection? ConfigureServices(IServiceCollection services)
    {
        return services;
    }

    public CategoryUpdate()
    {
        Name = "Category Update Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Updates an existing Category";
        ShortName = "Update Category";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.CategoryUpdate;
    }

    public async Task<Domain.Models.Category> Run(
       Domain.DataModels.Category.CategoryUpdateInputModel parameter,
       Func<CategoryUpdateInputModel, Task<Domain.Models.Category>> next
   )
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<ICategoryRepository>();
            if (_repository == null)
            {
                throw new NullReferenceException($"Category Create: Repository could not be null");
            }

            Domain.Models.Category entity = await next(parameter);

            if (entity == null)
            {
                var id = parameter.Id;
                var data = _repository.Mapper.Map<Domain.Models.Category>(parameter);
                entity = await _repository.GetOne(x => x.CategoryId == id);
                if (entity == null)
                {
                    throw new Exception($"Profile Category: Entity with id {id} was not found");
                }

                entity.Name = Is.ThenIfNullOrEmpty(parameter.Name.Value, entity.Name)!;
                entity.Code = Is.ThenIfNullOrEmpty(parameter.Code.Value, entity.Code)!;
                entity.ParentCategoryId = Is.ThenIfNullOrEmpty(parameter.ParentCategoryId.Value, entity.ParentCategoryId)!;

                await _repository.Update(id, entity);
            }

            await _repository.UnitOfWork.SaveAsync();

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