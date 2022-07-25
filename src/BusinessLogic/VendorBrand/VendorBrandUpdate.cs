namespace LasMarias.BusinessLogic.VendorBrand;

public class VendorBrandUpdate : IAsyncMiddleware<VendorBrandUpdateInputModel, Domain.Models.VendorBrand>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private IVendorBrandRepository? _repository;

    private IVendorRepository? _vRepository;

    private IBrandRepository? _bRepository;

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

    public VendorBrandUpdate()
    {
        Name = "VendorBrand Update Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Updates an existing VendorBrand";
        ShortName = "Update VendorBrand";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.VendorBrandUpdate;
    }

    public async Task<Domain.Models.VendorBrand> Run(
       Domain.DataModels.VendorBrand.VendorBrandUpdateInputModel parameter,
       Func<VendorBrandUpdateInputModel, Task<Domain.Models.VendorBrand>> next
   )
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IVendorBrandRepository>();
            _vRepository = _scope?.ServiceProvider.GetService<IVendorRepository>();
            _bRepository = _scope?.ServiceProvider.GetService<IBrandRepository>();

            if (_repository == null || _vRepository == null || _bRepository == null)
            {
                throw new NullReferenceException($"VendorBrand Update: Repository could not be null");
            }

            Domain.Models.VendorBrand entity = await next(parameter);

            if (entity == null)
            {
                var id = parameter.Id;
                var data = _repository.Mapper.Map<Domain.Models.VendorBrand>(parameter);
                entity = await _repository.GetOne(x => x.VendorBrandId == id);
                if (entity == null)
                {
                    throw new Exception($"Profile VendorBrand: Entity with id {id} was not found");
                }

                if (!Is.NullOrEmpty(parameter.VendorId))
                {
                    if (!(await _vRepository.Any(x => x.VendorId == parameter.VendorId)))
                    {
                        throw new Exception($"Vendor with id {parameter.VendorId} was not found");
                    }
                    entity.VendorId = parameter.VendorId;
                }

                if (!Is.NullOrEmpty(parameter.BrandId))
                {
                    if (!(await _bRepository.Any(x => x.BrandId == parameter.BrandId)))
                    {
                        throw new Exception($"Brand with id {parameter.BrandId} was not found");
                    }
                    entity.BrandId = parameter.BrandId;
                }

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