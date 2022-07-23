namespace LasMarias.BusinessLogic.ProductMovement;

public class ProductMovementCreate :
    IAsyncMiddleware<ProductMovementCreateInputModel, Domain.Models.ProductMovement>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private IProductMovementRepository? _repository;

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

    public ProductMovementCreate()
    {
        Name = "ProductMovement Create Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Creates new ProductMovement";
        ShortName = "ProductMovement creation";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.ProductMovementCreate;
    }

    public async Task<Domain.Models.ProductMovement> Run(
        ProductMovementCreateInputModel input,
        Func<ProductMovementCreateInputModel, Task<Domain.Models.ProductMovement>> next
    )
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IProductMovementRepository>();

            if (_repository == null)
            {
                throw new NullReferenceException($"ProductMovement Create: Repository could not be null");
            }

            Domain.Models.ProductMovement entity = await next(input);

            if (entity == null)
            {
                var data = _repository.Mapper.Map<Domain.Models.ProductMovement>(input);
                entity = await _repository.Create(data);
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