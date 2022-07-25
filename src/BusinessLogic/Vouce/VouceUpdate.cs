namespace LasMarias.BusinessLogic.Vouce;

public class VouceUpdate : IAsyncMiddleware<VouceUpdateInputModel, Domain.Models.Vouce>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private IVouceRepository? _repository;

    private IProductMovementRepository? _mRepository;

    private IApplicationUserRepository? _uRepository;

    private IProductRepository? _pRepository;

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

    public VouceUpdate()
    {
        Name = "Vouce Update Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Updates an existing Vouce";
        ShortName = "Update Vouce";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.VouceUpdate;
    }

    public async Task<Domain.Models.Vouce> Run(
       Domain.DataModels.Vouce.VouceUpdateInputModel parameter,
       Func<VouceUpdateInputModel, Task<Domain.Models.Vouce>> next
   )
    {
        var movementList = new List<long>();
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IVouceRepository>();
            _mRepository = _scope?.ServiceProvider.GetService<IProductMovementRepository>();
            _uRepository = _scope?.ServiceProvider.GetService<IApplicationUserRepository>();
            _pRepository = _scope?.ServiceProvider.GetService<IProductRepository>();

            var chain = _scope?.ServiceProvider.GetService<IChainOfResponsibilityService>();

            if (_repository == null || _mRepository == null || _uRepository == null)
            {
                throw new NullReferenceException($"Vouce Update: Repository could not be null");
            }

            Domain.Models.Vouce entity = await next(parameter);

            if (entity == null)
            {
                var id = parameter.Id;
                var data = _repository.Mapper.Map<Domain.Models.Vouce>(parameter);
                entity = await _repository.GetOne(x => x.VouceId == id);
                if (entity == null)
                {
                    throw new Exception($"Profile Vouce: Entity with id {id} was not found");
                }

                if (!Is.NullOrEmpty(parameter.ApplicationUserId.Value!))
                {
                    if (!(await _uRepository.Any(x => x.Id == parameter.ApplicationUserId)))
                    {
                        throw new Exception($"user with id {parameter.ApplicationUserId} was not found");
                    }
                    entity.ApplicationUserId = parameter.ApplicationUserId;
                }

                if (!Is.NullOrAnyNull(parameter.ProductMovements))
                {
                    foreach (var pm in parameter.ProductMovements.Value!)
                    {
                        var product = await _pRepository!.GetOne(x => x.ProductId == pm.ProductId);
                        if (product == null)
                        {
                            throw new Exception($"Product with id {pm.ProductId} was not found");
                        }
                        if (pm.Movement!.ApplicationUserId == null)
                        {
                            pm.Movement.ApplicationUserId = entity.ApplicationUserId!;
                        }

                        var mov = await chain!.ExecuteAsyncChain<MovementCreateInputModel, Domain.Models.Movement>(
                            EventCodes.MovementCreate,
                            pm.Movement!
                        );

                        var pmEnt = await chain!.ExecuteAsyncChain<ProductMovementCreateInputModel, Domain.Models.ProductMovement>(
                            EventCodes.ProductMovementCreate,
                            new ProductMovementCreateInputModel
                            {
                                VouceId = id,
                                MovementId = mov.MovementId,
                                ProductId = pm.ProductId
                            }
                        );
                        movementList.Add(pmEnt.ProductMovementId);
                        entity.ProductMovements.Add(pmEnt);
                    }
                }

                await _repository.Update(id, entity);
            }

            await _repository.UnitOfWork.SaveAsync();

            return await Task.FromResult(entity);
        }
        catch (Exception ex)
        {
            if (movementList.Count() > 0)
            {
                foreach (var id in movementList)
                {
                    await _mRepository!.Delete(id);
                }
                await _mRepository!.UnitOfWork.SaveAsync();
            }
            Log.Error($"Exception running plugin {ShortName}: event {EventCode}: {ex.FullMessage()}");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }
}