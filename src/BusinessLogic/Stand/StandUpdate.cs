namespace LasMarias.BusinessLogic.Stand;

public class StandUpdate : IAsyncMiddleware<StandUpdateInputModel, Domain.Models.Stand>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private IStandRepository? _repository;

    private ITableRepository? _tRepository;

    private ISeatRepository? _sRepository;

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

    public StandUpdate()
    {
        Name = "Stand Update Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Updates an existing Stand";
        ShortName = "Update Stand";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.StandUpdate;
    }

    public async Task<Domain.Models.Stand> Run(
       Domain.DataModels.Stand.StandUpdateInputModel parameter,
       Func<StandUpdateInputModel, Task<Domain.Models.Stand>> next
   )
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IStandRepository>();
            _tRepository = _scope?.ServiceProvider.GetService<ITableRepository>();
            _sRepository = _scope?.ServiceProvider.GetService<ISeatRepository>();

            if (_repository == null || _tRepository == null || _sRepository == null)
            {
                throw new NullReferenceException($"Stand Update: Repository could not be null");
            }

            Domain.Models.Stand entity = await next(parameter);

            if (entity == null)
            {
                var id = parameter.Id;
                var data = _repository.Mapper.Map<Domain.Models.Stand>(parameter);
                entity = await _repository.GetOne(x => x.StandId == id);
                if (entity == null)
                {
                    throw new Exception($"Profile Stand: Entity with id {id} was not found");
                }

                if (!Is.NullOrEmpty(parameter.TableIds))
                {
                    foreach (var eid in parameter.TableIds.Value!)
                    {
                        var ent = await _tRepository.GetOne(x => x.TableId == eid);
                        if (ent == null)
                        {
                            throw new Exception($"Table with id {eid} was not found");
                        }
                        if (!entity.Tables!.Any(x => x.TableId == eid))
                        {
                            entity.Tables!.Add(ent);
                        }
                    }
                }
                else
                {
                    throw new Exception($"TableIds could not be null or empty");
                }

                if (!Is.NullOrEmpty(parameter.SeatIds))
                {
                    foreach (var eid in parameter.SeatIds.Value!)
                    {
                        var ent = await _sRepository.GetOne(x => x.SeatId == eid);
                        if (ent == null)
                        {
                            throw new Exception($"Seat with id {eid} was not found");
                        }
                        if (!entity.Seats!.Any(x => x.SeatId == eid))
                        {
                            entity.Seats!.Add(ent);
                        }
                    }
                }
                else
                {
                    throw new Exception($"TableIds could not be null or empty");
                }

                entity.Name = Is.ThenIfNullOrEmpty(parameter.Name.Value, entity.Name)!;
                entity.Enable = Is.ThenIfNullOrEmpty(parameter.Enable.Value, entity.Enable)!;
                entity.Reserved = Is.ThenIfNullOrEmpty(parameter.Reserved.Value, entity.Reserved)!;
                entity.StandType = Is.ThenIfNullOrEmpty(parameter.StandType.Value, entity.StandType)!;

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