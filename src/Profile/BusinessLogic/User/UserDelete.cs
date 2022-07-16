namespace LasMarias.Profile.BusinessLogic.User;

public class UserDelete : IAsyncMiddleware<long, bool>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private IEmployeeRepository? _repository;

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

    public UserDelete()
    {
        Name = "Profle User Delete Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "deletes an user data if is available";
        ShortName = "Profile User Delete";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.UserDelete;
    }

    public async Task<bool> Run(long parameter, Func<long, Task<bool>> next)
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IEmployeeRepository>();
            if (_repository == null)
            {
                throw new NullReferenceException($"User Delete: Repository could not be null");
            }
            await _repository?.Delete(parameter)!;
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