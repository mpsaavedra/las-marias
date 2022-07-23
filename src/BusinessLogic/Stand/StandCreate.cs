namespace LasMarias.BusinessLogic.Stand;

public class StandCreate :
    IAsyncMiddleware<StandCreateInputModel, Domain.Models.Stand>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private IStandRepository? _repository;

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

    public StandCreate()
    {
        Name = "Stand Create Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Creates new Stand";
        ShortName = "Stand creation";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.StandCreate;
    }

    public async Task<Domain.Models.Stand> Run(
        StandCreateInputModel input,
        Func<StandCreateInputModel, Task<Domain.Models.Stand>> next
    )
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IStandRepository>();

            if (_repository == null)
            {
                throw new NullReferenceException($"Stand Create: Repository could not be null");
            }

            Domain.Models.Stand entity = await next(input);

            if (entity == null)
            {
                var data = _repository.Mapper.Map<Domain.Models.Stand>(input);
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