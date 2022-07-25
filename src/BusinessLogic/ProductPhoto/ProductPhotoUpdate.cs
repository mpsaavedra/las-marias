namespace LasMarias.BusinessLogic.ProductPhoto;

public class ProductPhotoUpdate : IAsyncMiddleware<ProductPhotoUpdateInputModel, Domain.Models.ProductPhoto>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private IProductPhotoRepository? _repository;

    private IProductRepository? _pRepository;

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

    public ProductPhotoUpdate()
    {
        Name = "ProductPhoto Update Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Updates an existing ProductPhoto";
        ShortName = "Update ProductPhoto";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.ProductPhotoUpdate;
    }

    public async Task<Domain.Models.ProductPhoto> Run(
       Domain.DataModels.ProductPhoto.ProductPhotoUpdateInputModel parameter,
       Func<ProductPhotoUpdateInputModel, Task<Domain.Models.ProductPhoto>> next
   )
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IProductPhotoRepository>();
            _pRepository = _scope?.ServiceProvider.GetService<IProductRepository>();

            if (_repository == null || _pRepository == null)
            {
                throw new NullReferenceException($"ProductPhoto Create: Repository could not be null");
            }

            Domain.Models.ProductPhoto entity = await next(parameter);

            if (entity == null)
            {
                var id = parameter.Id;
                var data = _repository.Mapper.Map<Domain.Models.ProductPhoto>(parameter);
                entity = await _repository.GetOne(x => x.ProductPhotoId == id);
                if (entity == null)
                {
                    throw new Exception($"Profile ProductPhoto: Entity with id {id} was not found");
                }

                if (!Is.NullOrEmpty(parameter.ProductId))
                {
                    if (!(await _pRepository.Any(x => x.ProductId == parameter.ProductId)))
                    {
                        throw new Exception($"Product with id {parameter.ProductId} was not found");
                    }
                    entity.ProductId = parameter.ProductId;
                }

                entity.ContentType = Is.ThenIfNullOrEmpty(parameter.ContentType.Value, entity.ContentType);
                entity.Data = Is.ThenIfNullOrEmpty(parameter.Data.Value, entity.Data);
                entity.PhotoUrl = Is.ThenIfNullOrEmpty(parameter.PhotoUrl.Value, entity.PhotoUrl);
                entity.DesignColor = Is.ThenIfNullOrEmpty(parameter.DesignColor.Value, entity.DesignColor);
                entity.DefaultPhoto = Is.ThenIfNullOrEmpty(parameter.DefaultPhoto.Value, entity.DefaultPhoto);

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