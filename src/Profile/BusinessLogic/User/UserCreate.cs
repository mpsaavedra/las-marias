namespace LasMarias.Profile.BusinessLogic.User;

public class UserCreate : IAsyncMiddleware<UserCreateInputModel,
    Domain.Models.User>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private IUserRepository? _repository;

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

    public UserCreate(IChainOfResponsibilityService chain)
    {
        Name = "Profile User Create Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "creates a new User";
        ShortName = "Profile Create User";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.UserCreate;
        _chain = chain;
    }

    public async Task<Domain.Models.User> Run(UserCreateInputModel parameter,
        Func<UserCreateInputModel, Task<Domain.Models.User>> next)
    {
        long employeeId = 0;
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IUserRepository>();
            if (_repository == null)
            {
                throw new NullReferenceException($"User Create: Repository could not be null");
            }

            Domain.Models.User entity = await next(parameter);

            if (entity == null)
            {
                if ((await _repository.Any(x => x.ApplicationUserId == parameter.ApplicationUserId)))
                {
                    throw new Exception($"User Create: an use with the id {parameter.ApplicationUserId} already exists");
                }

                var data = _repository.Mapper.Map<Domain.Models.User>(parameter);
                entity = await _repository.Create(data);

                // employee related data
                if (Is.NotNullOrAnyNotNull(parameter.EmployeeType, parameter.DateOfBirth, parameter.Status, parameter.HiredDate))
                {
                    if (entity.Employee == null)
                    {
                        Log.Debug("Profile User: Creating new employee data");
                        var employeeData = new EmployeeCreateInputModel();

                        employeeData.UserId = entity.UserId;
                        employeeData.DateOfBirth = parameter.DateOfBirth;
                        employeeData.Status = parameter.Status;
                        employeeData.HiredDate = parameter.HiredDate;

                        var employee = await _chain.ExecuteAsyncChain<EmployeeCreateInputModel, Domain.Models.Employee>(
                            EventCodes.EmployeeCreate,
                            employeeData
                        );
                        employee = employee.IsNullOrEmpty("Employee related data could not be created");

                        entity.Employee = employee;
                    }
                    else
                    {
                        entity.Employee.DateOfBirth = parameter.DateOfBirth.ThenIfNullOrEmpty(parameter.DateOfBirth);
                        entity.Employee.Status = parameter.Status.ThenIfNullOrEmpty(parameter.Status);
                        entity.Employee.HiredDate = parameter.HiredDate.ThenIfNullOrEmpty(parameter.HiredDate);
                    }

                    employeeId = entity.Employee.EmployeeId;
                }

            }

            await _repository.UnitOfWork.SaveAsync();

            return await Task.FromResult(entity);
        }
        catch (Exception ex)
        {
            if (employeeId > 0)
            {
                await _chain.ExecuteAsyncChain<long, bool>(
                    EventCodes.EmployeeDelete,
                    employeeId
                );
            }

            Log.Error($"Exception running plugin {ShortName}: event {EventCode}: {ex.FullMessage()}");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }

}