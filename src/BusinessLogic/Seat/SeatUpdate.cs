namespace LasMarias.BusinessLogic.Seat;

public class SeatUpdate : IAsyncMiddleware<SeatUpdateInputModel, Domain.Models.Seat>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private ISeatRepository? _repository;

    private ITableRepository? _tRepository;

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

    public SeatUpdate()
    {
        Name = "Seat Update Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Updates an existing Seat";
        ShortName = "Update Seat";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.SeatUpdate;
    }

    public async Task<Domain.Models.Seat> Run(
       Domain.DataModels.Seat.SeatUpdateInputModel parameter,
       Func<SeatUpdateInputModel, Task<Domain.Models.Seat>> next
   )
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<ISeatRepository>();
            _tRepository = _scope?.ServiceProvider.GetService<ITableRepository>();
            _sRepository = _scope?.ServiceProvider.GetService<IStandRepository>();

            if (_repository == null || _tRepository == null || _sRepository == null)
            {
                throw new NullReferenceException($"Seat Update: Repository could not be null");
            }

            Domain.Models.Seat entity = await next(parameter);

            if (entity == null)
            {
                var id = parameter.Id;
                var data = _repository.Mapper.Map<Domain.Models.Seat>(parameter);
                entity = await _repository.GetOne(x => x.SeatId == id);
                if (entity == null)
                {
                    throw new Exception($"Profile Seat: Entity with id {id} was not found");
                }

                if (!Is.NullOrEmpty(parameter.TableId))
                {
                    if (!(await _tRepository.Any(x => x.TableId == parameter.TableId)))
                    {
                        throw new Exception($"Table with id {parameter.TableId} was not found");
                    }
                    entity.TableId = parameter.TableId;
                }

                if (!Is.NullOrEmpty(parameter.StandId))
                {
                    if (!(await _sRepository.Any(x => x.StandId == parameter.StandId)))
                    {
                        throw new Exception($"Stand with id {parameter.TableId} was not found");
                    }
                    entity.StandId = parameter.StandId;
                }

                entity.Code = Is.ThenIfNullOrEmpty(parameter.Code.Value, entity.Code);
                entity.InventaryNumber = Is.ThenIfNullOrEmpty(parameter.InventaryNumber.Value, entity.InventaryNumber);
                entity.SeatType = Is.ThenIfNullOrEmpty(parameter.SeatType.Value, entity.SeatType);
                entity.Occupied = Is.ThenIfNullOrEmpty(parameter.Occupied.Value, entity.Occupied);

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