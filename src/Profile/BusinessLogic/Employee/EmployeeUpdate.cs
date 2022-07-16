namespace LasMarias.Profile.BusinessLogic.Employee;

public class EmployeeUpdate : IAsyncMiddleware<Domain.DataModels.Employee.EmployeeUpdateInputModel, Domain.Models.Employee>, IMiddlewarePlugin
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

    public EmployeeUpdate()
    {
        Name = "Profile Employee Update Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Updates an existing Employee";
        ShortName = "Profile Update Employee";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.EmployeeUpdate;
    }

    public async Task<Domain.Models.Employee> Run(
        Domain.DataModels.Employee.EmployeeUpdateInputModel parameter,
        Func<Domain.DataModels.Employee.EmployeeUpdateInputModel, Task<Domain.Models.Employee>> next
    )
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IEmployeeRepository>();
            if (_repository == null)
            {
                throw new NullReferenceException($"User Create: Repository could not be null");
            }

            Domain.Models.Employee entity = await next(parameter);

            if (entity == null)
            {
                var id = parameter.Id;
                var data = _repository.Mapper.Map<Domain.Models.Employee>(parameter);
                entity = await _repository.GetOne(x => x.EmployeeId == id);
                if (entity == null)
                {
                    throw new Exception($"Profile Employee: Entity with id {id} was not found");
                }

                entity.UserId = data.UserId.ThenIfNullOrEmpty(entity.UserId);
                entity.EmployeeType = data.EmployeeType.ThenIfNullOrEmpty(entity.EmployeeType);
                entity.Status = data.Status.ThenIfNullOrEmpty(entity.Status);
                entity.HiredDate = data.HiredDate.ThenIfNullOrEmpty(entity.HiredDate);
                entity.ReleaseDate = data.ReleaseDate.ThenIfNullOrEmpty(entity.ReleaseDate);
                entity.ReleaseReason = data.ReleaseReason.ThenIfNullOrEmpty(entity.ReleaseReason);
                entity.ReleaseNote = data.ReleaseNote.ThenIfNullOrEmpty(entity.ReleaseNote);

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