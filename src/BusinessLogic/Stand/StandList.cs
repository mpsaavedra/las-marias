namespace LasMarias.BusinessLogic.Stand;

public class StandList : IAsyncMiddleware<StandListPayload, bool>, IMiddlewarePlugin
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

    public StandList()
    {
        Name = "Stand List Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "returns Stand list ";
        ShortName = "Stand List";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.StandList;
    }

    public async Task<bool> Run(StandListPayload parameter, Func<StandListPayload, Task<bool>> next)
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IStandRepository>();
            if (_repository == null)
            {
                throw new NullReferenceException($"Stand: Repository could not be null");
            }
            parameter.Payload = await _repository?.Get(x => !x.Deleted)!;
            return await next(parameter);
        }
        catch (Exception ex)
        {
            Log.Error($"Exception running plugin {ShortName}: event {EventCode}: {ex.FullMessage()}");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }

}