namespace LasMarias.BusinessLogic.PlateCategory;

public class PlateCategoryUpdate : IAsyncMiddleware<PlateCategoryUpdateInputModel, Domain.Models.PlateCategory>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private IPlateCategoryRepository? _repository;

    private IPlateRepository? _pRepository;

    private ICategoryRepository? _cRepository;

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

    public PlateCategoryUpdate()
    {
        Name = "PlateCategory Update Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Updates an existing PlateCategory";
        ShortName = "Update PlateCategory";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.PlateCategoryUpdate;
    }

    public async Task<Domain.Models.PlateCategory> Run(
       Domain.DataModels.PlateCategory.PlateCategoryUpdateInputModel parameter,
       Func<PlateCategoryUpdateInputModel, Task<Domain.Models.PlateCategory>> next
   )
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IPlateCategoryRepository>();
            _pRepository = _scope?.ServiceProvider.GetService<IPlateRepository>();
            _cRepository = _scope?.ServiceProvider.GetService<ICategoryRepository>();

            if (_repository == null)
            {
                throw new NullReferenceException($"PlateCategory: Repository could not be null");
            }

            if (_pRepository == null)
            {
                throw new NullReferenceException($"PlateCategory: Plate Repository could not be null");
            }

            if (_cRepository == null)
            {
                throw new NullReferenceException($"PlateCategory: Category Repository could not be null");
            }

            Domain.Models.PlateCategory entity = await next(parameter);

            if (entity == null)
            {
                var id = parameter.Id;
                var data = _repository.Mapper.Map<Domain.Models.PlateCategory>(parameter);
                entity = await _repository.GetOne(x => x.PlateCategoryId == id);
                if (entity == null)
                {
                    throw new Exception($"PlateCategory: Entity with id {id} was not found");
                }

                if (!Is.NullOrEmpty(parameter.PlateId))
                {
                    if (!(await _pRepository.Any(x => x.PlateId == parameter.PlateId)))
                    {
                        throw new Exception($"Plate with id {parameter.PlateId} was not found");
                    }

                    entity.PlateId = parameter.PlateId;
                }

                if (!Is.NullOrEmpty(parameter.CategoryId))
                {
                    if (!(await _cRepository.Any(x => x.CategoryId == parameter.CategoryId)))
                    {
                        throw new Exception($"Plate with id {parameter.CategoryId} was not found");
                    }

                    entity.CategoryId = parameter.CategoryId;
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