namespace LasMarias.BusinessLogic.Vouce;

public class VouceList : IAsyncMiddleware<VouceListPayload, bool>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private IVouceRepository? _repository;

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

    public VouceList()
    {
        Name = "Vouce List Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "returns Vouce list ";
        ShortName = "Vouce List";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.VouceList;
    }

    public async Task<bool> Run(VouceListPayload parameter, Func<VouceListPayload, Task<bool>> next)
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IVouceRepository>();
            if (_repository == null)
            {
                throw new NullReferenceException($"Vouce: Repository could not be null");
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