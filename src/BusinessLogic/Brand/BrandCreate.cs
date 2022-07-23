namespace LasMarias.BusinessLogic.Brand;

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

    public WebApplication? Configure(WebApplication builder)
    {
        _scope = builder.Services.CreateScope();
        return builder;
    }

    public IServiceCollection? ConfigureServices(IServiceCollection services)
    {
        return services;
    }

    public BrandCreate()
    {
        Name = "Brand Create Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Creates new Brand";
        ShortName = "Brand creation";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.BrandCreate;
    }

    public async Task<Domain.Models.Brand> Run(
        BrandCreateInputModel input,
        Func<BrandCreateInputModel, Task<Domain.Models.Brand>> next
    )
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IBrandRepository>();

            if (_repository == null)
            {
                throw new NullReferenceException($"Brand Create: Repository could not be null");
            }

            Domain.Models.Brand entity = await next(input);

            if (entity == null)
            {
                var data = _repository.Mapper.Map<Domain.Models.Brand>(input);
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