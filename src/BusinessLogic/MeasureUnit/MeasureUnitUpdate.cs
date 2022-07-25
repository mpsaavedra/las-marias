namespace LasMarias.BusinessLogic.MeasureUnit;

public class MeasureUnitUpdate : IAsyncMiddleware<MeasureUnitUpdateInputModel, Domain.Models.MeasureUnit>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private IMeasureUnitRepository? _repository;

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

    public MeasureUnitUpdate()
    {
        Name = "MeasureUnit Update Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Updates an existing MeasureUnit";
        ShortName = "Update MeasureUnit";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.MeasureUnitUpdate;
    }

    public async Task<Domain.Models.MeasureUnit> Run(
       Domain.DataModels.MeasureUnit.MeasureUnitUpdateInputModel parameter,
       Func<MeasureUnitUpdateInputModel, Task<Domain.Models.MeasureUnit>> next
   )
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IMeasureUnitRepository>();
            if (_repository == null)
            {
                throw new NullReferenceException($"MeasureUnit Create: Repository could not be null");
            }

            Domain.Models.MeasureUnit entity = await next(parameter);

            if (entity == null)
            {
                var id = parameter.Id;
                var data = _repository.Mapper.Map<Domain.Models.MeasureUnit>(parameter);
                entity = await _repository.GetOne(x => x.MeasureUnitId == id);
                if (entity == null)
                {
                    throw new Exception($"MeasureUnit: Entity with id {id} was not found");
                }

                entity.Name = Is.ThenIfNullOrEmpty(parameter.Name.Value, entity.Name)!;
                entity.Code = Is.ThenIfNullOrEmpty(parameter.Code.Value, entity.Code)!;
                entity.Cast = Is.ThenIfNullOrEmpty(parameter.Cast.Value, entity.Cast)!;
                entity.Enable = Is.ThenIfNullOrEmpty(parameter.Enable.Value, entity.Enable)!;

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