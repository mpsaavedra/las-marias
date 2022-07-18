namespace LasMarias.Profile.BusinessLogic.Employee;

public class EmployeeCreate : IAsyncMiddleware<EmployeeCreateInputModel,
    Domain.Models.Employee>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private IEmployeeRepository? _repository;

    private IChainOfResponsibilityService _chain;

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

    public EmployeeCreate()
    {
        Name = "Profile Employee Create Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "creates a new Employee";
        ShortName = "Profile Create Employee";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.EmployeeCreate;
    }

    public async Task<Domain.Models.Employee> Run(EmployeeCreateInputModel parameter,
        Func<EmployeeCreateInputModel, Task<Domain.Models.Employee>> next)
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IEmployeeRepository>();
            _chain = _scope?.ServiceProvider.GetService<IChainOfResponsibilityService>()!;

            if (_repository == null)
            {
                throw new NullReferenceException($"Employee Create: Repository could not be null");
            }

            if ((await _repository.Any(x => x.UserId == parameter.UserId)))
            {
                throw new Exception($"Employee Create: An employee with user id {parameter.UserId} already exists");
            }

            Domain.Models.Employee entity = await next(parameter);

            if (entity == null)
            {
                var data = _repository.Mapper.Map<Domain.Models.Employee>(parameter);
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