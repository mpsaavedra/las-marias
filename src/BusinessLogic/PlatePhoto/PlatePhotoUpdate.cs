namespace LasMarias.BusinessLogic.PlatePhoto;

public class PlatePhotoUpdate : IAsyncMiddleware<PlatePhotoUpdateInputModel, Domain.Models.PlatePhoto>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private IPlatePhotoRepository? _repository;

    private IPlateRepository? _pRepository;

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

    public PlatePhotoUpdate()
    {
        Name = "PlatePhoto Update Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Updates an existing PlatePhoto";
        ShortName = "Update PlatePhoto";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.PlatePhotoUpdate;
    }

    public async Task<Domain.Models.PlatePhoto> Run(
       Domain.DataModels.PlatePhoto.PlatePhotoUpdateInputModel parameter,
       Func<PlatePhotoUpdateInputModel, Task<Domain.Models.PlatePhoto>> next
   )
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IPlatePhotoRepository>();
            _pRepository = _scope?.ServiceProvider.GetService<IPlateRepository>();

            if (_repository == null)
            {
                throw new NullReferenceException($"PlatePhoto: Repository could not be null");
            }

            if (_Repository == null)
            {
                throw new NullReferenceException($"PlatePhoto: Plate Repository could not be null");
            }

            Domain.Models.PlatePhoto entity = await next(parameter);

            if (entity == null)
            {
                var id = parameter.Id;
                var data = _repository.Mapper.Map<Domain.Models.PlatePhoto>(parameter);
                entity = await _repository.GetOne(x => x.PlatePhotoId == id);
                if (entity == null)
                {
                    throw new Exception($"Profile PlatePhoto: Entity with id {id} was not found");
                }

                if (!(await _pRepository.Any(x => x.PlateId = parameter.PlateId)))
                {
                    throw new Exception($"Plate with id {parameter.PlateId} was not found");
                }

                entity.PlateId = parameter.PlateId;
                entity.ContentType = Is.ThenIfNullOrEmpty(parameter.ContentType.Value, entity.ContentType)!;
                entity.Data = Is.ThenIfNullOrEmpty(parameter.Data.Value, entity.Data)!;
                entity.PhotoUrl = Is.ThenIfNullOrEmpty(parameter.PhotoUrl.Value, entity.Data)!;
                entity.DesignColor = Is.ThenIfNullOrEmpty(parameter.DesignColor.Value, entity.Data)!;
                entity.DefaultPhoto = Is.ThenIfNullOrEmpty(parameter.DefaultPhoto.Value, entity.Data)!;

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