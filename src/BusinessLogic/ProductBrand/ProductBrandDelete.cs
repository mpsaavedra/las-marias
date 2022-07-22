namespace LasMarias.BusinessLogic.ProductBrand;

public class ProductBrandDelete : IAsyncMiddleware<long, bool>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private IProductBrandRepository? _repository;

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

    public ProductBrandDelete()
    {
        Name = "ProductBrand Delete Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Deletes ProductBrand from list ";
        ShortName = "ProductBrand deletion";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.ProductBrandDelete;
    }

    public async Task<bool> Run(long id, Func<long, Task<bool>> next)
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            var deleted = false;

            _repository = _scope?.ServiceProvider.GetService<IProductBrandRepository>();
            if (_repository == null)
            {
                throw new NullReferenceException($"ProductBrand: Repository could not be null");
            }
            deleted = await next(id);

            if (!deleted)
            {
                Domain.Models.ProductBrand entity = await _repository.GetOne(x => x.ProductBrandId == id);
                if (Is.NullOrEmpty(entity))
                {
                    throw new Exception($"ProductBrand: Entity with id {id} was not found"); ;
                }
                deleted = await _repository.Delete(id);
            }
            await _repository.UnitOfWork.SaveAsync();

            return await Task.FromResult(deleted);
        }
        catch (Exception ex)
        {
            Log.Error($"Exception running plugin {ShortName}: event {EventCode}: {ex.FullMessage()}");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }

}