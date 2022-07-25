namespace LasMarias.BusinessLogic.ProductBrand;

public class ProductBrandUpdate : IAsyncMiddleware<ProductBrandUpdateInputModel, Domain.Models.ProductBrand>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private IProductBrandRepository? _repository;

    private IProductRepository? _pRepository;

    private IBrandRepository? _bRepository;

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

    public ProductBrandUpdate()
    {
        Name = "ProductBrand Update Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Updates an existing ProductBrand";
        ShortName = "Update ProductBrand";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.ProductBrandUpdate;
    }

    public async Task<Domain.Models.ProductBrand> Run(
       Domain.DataModels.ProductBrand.ProductBrandUpdateInputModel parameter,
       Func<ProductBrandUpdateInputModel, Task<Domain.Models.ProductBrand>> next
   )
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IProductBrandRepository>();
            _pRepository = _scope?.ServiceProvider.GetService<IProductRepository>();
            _bRepository = _scope?.ServiceProvider.GetService<IBrandRepository>();

            if (Is.NullOrEmpty(_repository!, _pRepository!, _bRepository!))
            {
                throw new NullReferenceException($"ProductBrand Update: Repository could not be null");
            }

            Domain.Models.ProductBrand entity = await next(parameter);

            if (entity == null)
            {
                var id = parameter.Id;
                var data = _repository!.Mapper.Map<Domain.Models.ProductBrand>(parameter);
                entity = await _repository.GetOne(x => x.ProductBrandId == id);
                if (entity == null)
                {
                    throw new Exception($"ProductBrand Update: Entity with id {id} was not found");
                }

                if (!Is.NullOrEmpty(parameter.ProductId))
                {
                    if (!(await _pRepository!.Any(x => x.ProductId == parameter.ProductId)))
                    {
                        throw new Exception($"Product with id {parameter.ProductId} was not found");
                    }
                    entity.ProductId = parameter.ProductId;
                }

                if (!Is.NullOrEmpty(parameter.BrandId))
                {
                    if (!(await _bRepository!.Any(x => x.BrandId == parameter.BrandId)))
                    {
                        throw new Exception($"Product with id {parameter.BrandId} was not found");
                    }
                    entity.BrandId = parameter.BrandId;
                }

                await _repository.Update(id, entity);
            }

            await _repository!.UnitOfWork.SaveAsync();

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