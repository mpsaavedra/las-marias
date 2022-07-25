namespace LasMarias.BusinessLogic.Brand;

public class BrandUpdate : IAsyncMiddleware<BrandUpdateInputModel, Domain.Models.Brand>, IMiddlewarePlugin
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

    public WebApplication? Configure(WebApplication builder)
    {
        _scope = builder.Services.CreateScope();
        return builder;
    }

    public IServiceCollection? ConfigureServices(IServiceCollection services)
    {
        return services;
    }

    public BrandUpdate()
    {
        Name = "Brand Update Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Updates an existing Brand";
        ShortName = "Update Brand";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.BrandUpdate;
    }

    public async Task<Domain.Models.Brand> Run(
       Domain.DataModels.Brand.BrandUpdateInputModel parameter,
       Func<BrandUpdateInputModel, Task<Domain.Models.Brand>> next
   )
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IBrandRepository>();
            if (_repository == null)
            {
                throw new NullReferenceException($"Brand Update: Repository could not be null");
            }

            Domain.Models.Brand entity = await next(parameter);

            if (entity == null)
            {
                var id = parameter.Id;
                var data = _repository.Mapper.Map<Domain.Models.Brand>(parameter);
                entity = await _repository.GetOne(x => x.BrandId == id);
                if (entity == null)
                {
                    throw new Exception($"Brand: Entity with id {id} was not found");
                }

                entity.Name = Is.ThenIfNullOrEmpty(parameter.Name.Value, entity.Name)!;
                entity.Enable = Is.ThenIfNullOrEmpty(parameter.Enable.Value, entity.Enable)!;

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