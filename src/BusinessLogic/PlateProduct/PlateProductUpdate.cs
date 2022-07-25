namespace LasMarias.BusinessLogic.PlateProduct;

public class PlateProductUpdate : IAsyncMiddleware<PlateProductUpdateInputModel, Domain.Models.PlateProduct>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private IPlateProductRepository? _repository;

    private IPlateRepository? _pRepository;

    private IProductRepository? _prRepository;

    private IMeasureUnitRepository? _muRepository;

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

    public PlateProductUpdate()
    {
        Name = "PlateProduct Update Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Updates an existing PlateProduct";
        ShortName = "Update PlateProduct";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.PlateProductUpdate;
    }

    public async Task<Domain.Models.PlateProduct> Run(
       Domain.DataModels.PlateProduct.PlateProductUpdateInputModel parameter,
       Func<PlateProductUpdateInputModel, Task<Domain.Models.PlateProduct>> next
   )
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IPlateProductRepository>();
            _pRepository = _scope?.ServiceProvider.GetService<IPlateRepository>();
            _prRepository = _scope?.ServiceProvider.GetService<IProductRepository>();
            _muRepository = _scope?.ServiceProvider.GetService<IMeasureUnitRepository>();

            if (_repository == null)
            {
                throw new NullReferenceException($"PlateProduct: Repository could not be null");
            }

            if (_pRepository == null)
            {
                throw new NullReferenceException($"PlateProduct:Plate Repository could not be null");
            }

            if (_prRepository == null)
            {
                throw new NullReferenceException($"PlateProduct:Product Repository could not be null");
            }

            if (_muRepository == null)
            {
                throw new NullReferenceException($"PlateProduct:MeasureUnit Repository could not be null");
            }

            Domain.Models.PlateProduct entity = await next(parameter);

            if (entity == null)
            {
                var id = parameter.Id;
                var data = _repository.Mapper.Map<Domain.Models.PlateProduct>(parameter);
                entity = await _repository.GetOne(x => x.PlateProductId == id);
                if (entity == null)
                {
                    throw new Exception($"Profile PlateProduct: Entity with id {id} was not found");
                }

                if (!Is.NullOrEmpty(parameter.PlateId))
                {
                    if (!(await _pRepository.Any(x => x.PlateId == parameter.PlateId)))
                    {
                        throw new Exception($"Plate with id {parameter.PlateId} was not found");
                    }

                    entity.PlateId = parameter.PlateId;
                }

                if (!Is.NullOrEmpty(parameter.MeasureUnitId))
                {
                    if (!(await _muRepository.Any(x => x.MeasureUnitId == parameter.MeasureUnitId)))
                    {
                        throw new Exception($"MeasureUnit with id {parameter.MeasureUnitId} was not found");
                    }

                    entity.MeasureUnitId = parameter.MeasureUnitId;
                }

                if (!Is.NullOrEmpty(parameter.ProductId))
                {
                    if (!(await _prRepository.Any(x => x.ProductId == parameter.ProductId)))
                    {
                        throw new Exception($"MeasureUnit with id {parameter.ProductId} was not found");
                    }

                    entity.ProductId = parameter.ProductId;
                }

                entity.Amount = Is.ThenIfNullOrEmpty(parameter.Amount.Value, entity.Amount);

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