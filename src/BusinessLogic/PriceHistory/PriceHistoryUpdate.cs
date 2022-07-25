namespace LasMarias.BusinessLogic.PriceHistory;

public class PriceHistoryUpdate : IAsyncMiddleware<PriceHistoryUpdateInputModel, Domain.Models.PriceHistory>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private IPriceHistoryRepository? _repository;

    private IProductRepository? _pRepository;

    private IApplicationUserRepository? _uRepository;

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

    public PriceHistoryUpdate()
    {
        Name = "PriceHistory Update Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Updates an existing PriceHistory";
        ShortName = "Update PriceHistory";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.PriceHistoryUpdate;
    }

    public async Task<Domain.Models.PriceHistory> Run(
       Domain.DataModels.PriceHistory.PriceHistoryUpdateInputModel parameter,
       Func<PriceHistoryUpdateInputModel, Task<Domain.Models.PriceHistory>> next
   )
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IPriceHistoryRepository>();
            _uRepository = _scope?.ServiceProvider.GetService<IApplicationUserRepository>();
            _pRepository = _scope?.ServiceProvider.GetService<IProductRepository>();

            if (_repository == null)
            {
                throw new NullReferenceException($"PriceHistory: Repository could not be null");
            }

            if (_pRepository == null)
            {
                throw new NullReferenceException($"PriceHistory: Product Repository could not be null");
            }

            if (_uRepository == null)
            {
                throw new NullReferenceException($"PriceHistory: User Repository could not be null");
            }

            Domain.Models.PriceHistory entity = await next(parameter);

            if (entity == null)
            {
                var id = parameter.Id;
                var data = _repository.Mapper.Map<Domain.Models.PriceHistory>(parameter);
                entity = await _repository.GetOne(x => x.PriceHistoryId == id);
                if (entity == null)
                {
                    throw new Exception($"Profile PriceHistory: Entity with id {id} was not found");
                }

                if (!Is.NullOrEmpty(parameter.ProductId))
                {
                    if (!(await _pRepository.Any(x => x.ProductId == parameter.ProductId)))
                    {
                        throw new Exception($"Product with id {parameter.ProductId} was not found");
                    }
                    entity.ProductId = parameter.ProductId;
                }

                if (!Is.NullOrEmpty(parameter.ApplicationUserId))
                {
                    if (!(await _uRepository.Any(x => x.Id == parameter.ApplicationUserId)))
                    {
                        throw new Exception($"Product with id {parameter.ApplicationUserId} was not found");
                    }
                    entity.ApplicationUserId = parameter.ApplicationUserId;
                }

                entity.OldPrice = Is.ThenIfNullOrEmpty(parameter.OldPrice.Value, entity.OldPrice)!;
                entity.NewPrice = Is.ThenIfNullOrEmpty(parameter.NewPrice.Value, entity.NewPrice)!;

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