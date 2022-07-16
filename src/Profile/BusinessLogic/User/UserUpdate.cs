namespace LasMarias.Profile.BusinessLogic.User;

public class UserUpdate : IAsyncMiddleware<Domain.DataModels.User.UserUpdateInputModel, Domain.Models.User>, IMiddlewarePlugin
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

    public UserUpdate(IChainOfResponsibilityService chain)
    {
        Name = "Profile User Update Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Updates an existing User";
        ShortName = "Profile Update User";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.UserUpdate;
        _chain = chain;
    }

    public async Task<Domain.Models.User> Run(
        Domain.DataModels.User.UserUpdateInputModel parameter,
        Func<Domain.DataModels.User.UserUpdateInputModel, Task<Domain.Models.User>> next
    )
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
                var id = parameter.Id;
                var data = _repository.Mapper.Map<Domain.Models.User>(parameter);
                entity = await _repository.GetOne(x => x.UserId == id);
                if (entity == null)
                {
                    throw new Exception($"Profile User: Entity with id {id} was not found");
                }

                entity.ApplicationUserId = data.ApplicationUserId.ThenIfNullOrEmpty(entity.ApplicationUserId);
                entity.FirstName = data.FirstName.ThenIfNullOrEmpty(entity.FirstName);
                entity.LastName = data.LastName.ThenIfNullOrEmpty(entity.LastName);
                entity.DNI = data.DNI.ThenIfNullOrEmpty(entity.DNI);
                entity.PassportNumber = data.PassportNumber.ThenIfNullOrEmpty(entity.PassportNumber);
                entity.Gender = data.Gender.ThenIfNullOrEmpty(entity.Gender);
                entity.CountryId = data.CountryId.ThenIfNullOrEmpty(entity.CountryId);

                // employee related data
                if (Is.NotNullOrAnyNotNull(parameter.EmployeeType, parameter.DateOfBirth, parameter.Status,
                                          parameter.HiredDate, parameter.ReleaseDate, parameter.ReleaseReason,
                                          parameter.ReleaseNote))
                {
                    if (entity.Employee == null)
                    {
                        Log.Debug("Profile User: Creating new employee data");
                        var employeeData = new EmployeeCreateInputModel();

                        employeeData.UserId = parameter.Id;
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

                    if (entity.Employee.ReleaseDate != null)
                    {
                        entity.Employee.ReleaseDate = parameter.ReleaseDate;
                    }

                    if (entity.Employee.ReleaseReason != null)
                    {
                        entity.Employee.ReleaseReason = parameter.ReleaseReason;
                    }

                    if (entity.Employee.ReleaseNote != null)
                    {
                        entity.Employee.ReleaseNote = parameter.ReleaseNote;
                    }

                    employeeId = entity.Employee.EmployeeId;
                }

                await _repository.Update(id, entity);
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