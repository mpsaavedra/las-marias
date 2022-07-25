namespace LasMarias.BusinessLogic.Attribute;

public class AttributeUpdate : IAsyncMiddleware<AttributeUpdateInputModel, Domain.Models.Attribute>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private IAttributeRepository? _repository;

    private IMeasureUnitRepository? _muRepository;

    private IAttributeNameRepository? _anRepository;

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

    public AttributeUpdate()
    {
        Name = "Attribute Update Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Updates an existing Attribute";
        ShortName = "Update Attribute";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.AttributeUpdate;
    }

    public async Task<Domain.Models.Attribute> Run(
       Domain.DataModels.Attribute.AttributeUpdateInputModel parameter,
       Func<AttributeUpdateInputModel, Task<Domain.Models.Attribute>> next
   )
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IAttributeRepository>();
            _muRepository = _scope?.ServiceProvider.GetService<IMeasureUnitRepository>();
            _anRepository = _scope?.ServiceProvider.GetService<IAttributeNameRepository>();

            if (_repository == null)
            {
                throw new NullReferenceException($"Attribute Create: Repository could not be null");
            }

            if (_muRepository == null)
            {
                throw new NullReferenceException($"Attribute Create: Measure Unit Repository could not be null");
            }

            if (_anRepository == null)
            {
                throw new NullReferenceException($"Attribute Create: AttributeName Repository could not be null");
            }

            Domain.Models.Attribute entity = await next(parameter);

            if (entity == null)
            {
                var id = parameter.Id;
                var data = _repository.Mapper.Map<Domain.Models.Attribute>(parameter);
                entity = await _repository.GetOne(x => x.AttributeId == id);
                if (entity == null)
                {
                    throw new Exception($"Attribute: Entity with id {id} was not found");
                }

                if (!(await _muRepository.Any(x => x.MeasureUnitId == parameter.MeasureUnitId)))
                {
                    throw new Exception($"Attribute Update: MeasureUnit with id {parameter.MeasureUnitId} was not found");
                }

                if (!(await _anRepository.Any(x => x.AttributeNameId == parameter.AttributeNameId)))
                {
                    throw new Exception($"Attribute Update: Attribute Name with id {parameter.AttributeNameId} was not found");
                }

                entity.MeasureUnitId = Is.ThenIfNullOrEmpty(parameter.MeasureUnitId.Value, entity.MeasureUnitId);
                entity.MeasureUnitId = Is.ThenIfNullOrEmpty(parameter.AttributeNameId.Value, entity.AttributeNameId);
                entity.Value = Is.ThenIfNullOrEmpty(parameter.Value.Value, entity.Value)!;
                entity.Description = Is.ThenIfNullOrEmpty(parameter.Description.Value, entity.Description)!;

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