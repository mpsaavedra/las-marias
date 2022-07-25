namespace LasMarias.BusinessLogic.MenuPlate;

public class MenuPlateUpdate : IAsyncMiddleware<MenuPlateUpdateInputModel, Domain.Models.MenuPlate>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private IMenuPlateRepository? _repository;

    private IPlateRepository? _pRepository;

    private IMenuRepository? _mRepository;

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

    public MenuPlateUpdate()
    {
        Name = "MenuPlate Update Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Updates an existing MenuPlate";
        ShortName = "Update MenuPlate";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.MenuPlateUpdate;
    }

    public async Task<Domain.Models.MenuPlate> Run(
       Domain.DataModels.MenuPlate.MenuPlateUpdateInputModel parameter,
       Func<MenuPlateUpdateInputModel, Task<Domain.Models.MenuPlate>> next
   )
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IMenuPlateRepository>();
            _pRepository = _scope?.ServiceProvider.GetService<IPlateRepository>();
            _mRepository = _scope?.ServiceProvider.GetService<IMenuRepository>();

            if (_repository == null)
            {
                throw new NullReferenceException($"MenuPlate Update: Repository could not be null");
            }

            if (_pRepository == null)
            {
                throw new NullReferenceException($"MenuPlate Update: Plate Repository could not be null");
            }

            if (_mRepository == null)
            {
                throw new NullReferenceException($"MenuPlate Update: Menu Repository could not be null");
            }

            Domain.Models.MenuPlate entity = await next(parameter);

            if (entity == null)
            {
                var id = parameter.Id;
                var data = _repository.Mapper.Map<Domain.Models.MenuPlate>(parameter);
                entity = await _repository.GetOne(x => x.MenuPlateId == id);
                if (entity == null)
                {
                    throw new Exception($"MenuPlate: Entity with id {id} was not found");
                }

                if (!Is.NullOrEmpty(parameter.PlateId))
                {
                    if (!(await _pRepository.Any(x => x.PlateId == parameter.PlateId)))
                    {
                        entity.PlateId = parameter.PlateId;
                    }
                }

                if (!Is.NullOrEmpty(parameter.MenuId))
                {
                    if (!(await _mRepository.Any(x => x.MenuId == parameter.MenuId)))
                    {
                        entity.MenuId = parameter.MenuId;
                    }
                }

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