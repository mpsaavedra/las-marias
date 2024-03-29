namespace LasMarias.BusinessLogic.Plate;

public class PlateUpdate : IAsyncMiddleware<PlateUpdateInputModel, Domain.Models.Plate>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private IPlateRepository? _repository;

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

    public PlateUpdate()
    {
        Name = "Plate Update Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Updates an existing Plate";
        ShortName = "Update Plate";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.PlateUpdate;
    }

    public async Task<Domain.Models.Plate> Run(
       Domain.DataModels.Plate.PlateUpdateInputModel parameter,
       Func<PlateUpdateInputModel, Task<Domain.Models.Plate>> next
   )
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IPlateRepository>();
            if (_repository == null)
            {
                throw new NullReferenceException($"Plate Create: Repository could not be null");
            }

            Domain.Models.Plate entity = await next(parameter);

            if (entity == null)
            {
                var id = parameter.Id;
                var data = _repository.Mapper.Map<Domain.Models.Plate>(parameter);
                entity = await _repository.GetOne(x => x.PlateId == id);
                if (entity == null)
                {
                    throw new Exception($"Profile Plate: Entity with id {id} was not found");
                }

                entity.Name = Is.ThenIfNullOrEmpty(parameter.Name.Value, entity.Name)!;
                entity.Description = Is.ThenIfNullOrEmpty(parameter.Description.Value, entity.Description)!;
                entity.Recipe = Is.ThenIfNullOrEmpty(parameter.Recipe.Value, entity.Description)!;
                entity.SellingPrice = Is.ThenIfNullOrEmpty(parameter.SellingPrice.Value, entity.SellingPrice)!;
                entity.Available = Is.ThenIfNullOrEmpty(parameter.Available.Value, entity.Available)!;

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