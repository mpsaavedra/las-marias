namespace LasMarias.BusinessLogic.Employee;

public class EmployeeUpdate : IAsyncMiddleware<EmployeeUpdateInputModel, Domain.Models.Employee>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private IEmployeeRepository? _repository;

    private IApplicationUserRepository? _uRepository;

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

    public EmployeeUpdate()
    {
        Name = "Employee Update Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Updates an existing Employee";
        ShortName = "Update Employee";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.EmployeeUpdate;
    }

    public async Task<Domain.Models.Employee> Run(
       Domain.DataModels.Employee.EmployeeUpdateInputModel parameter,
       Func<EmployeeUpdateInputModel, Task<Domain.Models.Employee>> next
   )
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IEmployeeRepository>();
            _uRepository = _scope?.ServiceProvider.GetService<IApplicationUserRepository>();

            if (_repository == null)
            {
                throw new NullReferenceException($"Employee: Repository could not be null");
            }

            if (_uRepository == null)
            {
                throw new NullReferenceException($"Employee: User Repository could not be null");
            }

            Domain.Models.Employee entity = await next(parameter);

            if (entity == null)
            {
                var id = parameter.Id;
                var data = _repository.Mapper.Map<Domain.Models.Employee>(parameter);
                entity = await _repository.GetOne(x => x.EmployeeId == id);
                if (entity == null)
                {
                    throw new Exception($"Employee: Entity with id {id} was not found");
                }
                if (!Is.NullOrEmpty(parameter.UserId))
                {
                    if (!(await _uRepository.Any(x => x.Id == parameter.UserId)))
                    {
                        throw new Exception($"User with id {parameter.UserId} was not found"); ;
                    }
                    entity.UserId = parameter.UserId!;
                }

                entity.UserId = Is.ThenIfNullOrEmpty(parameter.UserId.Value, entity.UserId)!;
                entity.ReleaseDate = Is.ThenIfNullOrEmpty(parameter.ReleaseDate.Value, entity.ReleaseDate);
                entity.ReleaseReason = Is.ThenIfNullOrEmpty(parameter.ReleaseReason.Value, entity.ReleaseReason);
                entity.ReleaseNote = Is.ThenIfNullOrEmpty(parameter.ReleaseNote.Value, entity.ReleaseNote)!;
                entity.Status = Is.ThenIfNullOrEmpty(parameter.Status.Value, entity.Status);
                entity.EmployeeType = Is.ThenIfNullOrEmpty(parameter.EmployeeTye.Value, entity.EmployeeType);
                entity.DateOfBirth = Is.ThenIfNullOrEmpty(parameter.DateOfBirth.Value, entity.DateOfBirth);
                entity.HiredDate = Is.ThenIfNullOrEmpty(parameter.HiredDate.Value, entity.HiredDate);



                await _repository.Update(id, entity);
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