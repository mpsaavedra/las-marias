namespace LasMarias.Profile.BusinessLogic.Country;

public class CountryCreate : IAsyncMiddleware<CountryCreateInputModel,
    Domain.Models.Country>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private ICountryRepository? _repository;

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

    public CountryCreate()
    {
        Name = "Profile Country Create Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "creates a new Country";
        ShortName = "Profile Create Country";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.CountryCreate;
    }

    public async Task<Domain.Models.Country> Run(CountryCreateInputModel parameter,
        Func<CountryCreateInputModel, Task<Domain.Models.Country>> next)
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<ICountryRepository>();
            if (_repository == null)
            {
                throw new NullReferenceException($"Country Create: Repository could not be null");
            }

            Domain.Models.Country entity = await next(parameter);

            if (entity == null)
            {
                var data = _repository.Mapper.Map<Domain.Models.Country>(parameter);
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