namespace LasMarias.BusinessLogic.Movement;

public class MovementUpdate : IAsyncMiddleware<MovementUpdateInputModel, Domain.Models.Movement>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private IMovementRepository? _repository;

    private IApplicationUserRepository? _uRepository;

    private IVendorRepository? _vRepository;

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

    public MovementUpdate()
    {
        Name = "Movement Update Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Updates an existing Movement";
        ShortName = "Update Movement";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.MovementUpdate;
    }

    public async Task<Domain.Models.Movement> Run(
       Domain.DataModels.Movement.MovementUpdateInputModel parameter,
       Func<MovementUpdateInputModel, Task<Domain.Models.Movement>> next
   )
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IMovementRepository>();
            _uRepository = _scope?.ServiceProvider.GetService<IApplicationUserRepository>();
            _vRepository = _scope?.ServiceProvider.GetService<IVendorRepository>();

            if (_repository == null)
            {
                throw new NullReferenceException($"Movement: Repository could not be null");
            }

            if (_uRepository == null)
            {
                throw new NullReferenceException($"Movement: User Repository could not be null");
            }

            if (_vRepository == null)
            {
                throw new NullReferenceException($"Movement: Vendor Repository could not be null");
            }

            Domain.Models.Movement entity = await next(parameter);

            if (entity == null)
            {
                var id = parameter.Id;
                var data = _repository.Mapper.Map<Domain.Models.Movement>(parameter);
                entity = await _repository.GetOne(x => x.MovementId == id);
                if (entity == null)
                {
                    throw new Exception($"Movement: Entity with id {id} was not found");
                }

                if (!Is.NullOrEmpty(parameter.VendorId))
                {
                    if (!(await _vRepository.Any(x => x.VendorId == parameter.VendorId)))
                    {
                        throw new Exception($"Movement: Vendor with Id {parameter.VendorId} was not found");
                    }
                    entity.VendorId = parameter.VendorId!;
                }

                if (!Is.NullOrEmpty(parameter.UserId))
                {
                    if (!(await _uRepository.Any(x => x.Id == parameter.UserId)))
                    {
                        throw new Exception($"Movement: User with Id {parameter.UserId} was not found");
                    }
                    entity.ApplicationUserId = parameter.UserId!;
                }

                entity.Amount = Is.ThenIfNullOrEmpty(parameter.Amount.Value, entity.Amount);
                entity.Price = Is.ThenIfNullOrEmpty(parameter.Price.Value, entity.Price);
                entity.Description = Is.ThenIfNullOrEmpty(parameter.Description.Value, entity.Description);
                entity.StandType = Is.ThenIfNullOrEmpty(parameter.StandType.Value, entity.StandType);
                entity.MovementType = Is.ThenIfNullOrEmpty(parameter.MovementType.Value, entity.MovementType);

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