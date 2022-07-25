namespace LasMarias.BusinessLogic.Table;

public class TableUpdate : IAsyncMiddleware<TableUpdateInputModel, Domain.Models.Table>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private ITableRepository? _repository;

    private IStandRepository? _sRepository;

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

    public TableUpdate()
    {
        Name = "Table Update Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Updates an existing Table";
        ShortName = "Update Table";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.TableUpdate;
    }

    public async Task<Domain.Models.Table> Run(
       Domain.DataModels.Table.TableUpdateInputModel parameter,
       Func<TableUpdateInputModel, Task<Domain.Models.Table>> next
   )
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<ITableRepository>();
            _sRepository = _scope?.ServiceProvider.GetService<IStandRepository>();

            if (_repository == null || _sRepository == null)
            {
                throw new NullReferenceException($"Table Create: Repository could not be null");
            }

            Domain.Models.Table entity = await next(parameter);

            if (entity == null)
            {
                var id = parameter.Id;
                var data = _repository.Mapper.Map<Domain.Models.Table>(parameter);
                entity = await _repository.GetOne(x => x.TableId == id);
                if (entity == null)
                {
                    throw new Exception($"Profile Table: Entity with id {id} was not found");
                }

                if (!Is.NullOrEmpty(parameter.StandId))
                {
                    if (!(await _sRepository.Any(x => x.StandId == parameter.StandId)))
                    {
                        throw new Exception($"Stand with id {parameter.StandId} was not found");
                    }
                    entity.StandId = parameter.StandId;
                }

                entity.Name = Is.ThenIfNullOrEmpty(parameter.Name.Value, entity.Name)!;
                entity.InventaryNumber = Is.ThenIfNullOrEmpty(parameter.InventaryNumber.Value, entity.InventaryNumber)!;

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