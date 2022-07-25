namespace LasMarias.BusinessLogic.Vendor;

public class VendorUpdate : IAsyncMiddleware<VendorUpdateInputModel, Domain.Models.Vendor>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private IVendorRepository? _repository;

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

    public VendorUpdate()
    {
        Name = "Vendor Update Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Updates an existing Vendor";
        ShortName = "Update Vendor";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.VendorUpdate;
    }

    public async Task<Domain.Models.Vendor> Run(
       Domain.DataModels.Vendor.VendorUpdateInputModel parameter,
       Func<VendorUpdateInputModel, Task<Domain.Models.Vendor>> next
   )
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IVendorRepository>();
            if (_repository == null)
            {
                throw new NullReferenceException($"Vendor Create: Repository could not be null");
            }

            Domain.Models.Vendor entity = await next(parameter);

            if (entity == null)
            {
                var id = parameter.Id;
                var data = _repository.Mapper.Map<Domain.Models.Vendor>(parameter);
                entity = await _repository.GetOne(x => x.VendorId == id);
                if (entity == null)
                {
                    throw new Exception($"Profile Vendor: Entity with id {id} was not found");
                }

                entity.Name = Is.ThenIfNullOrEmpty(parameter.Name.Value, entity.Name)!;
                entity.Description = Is.ThenIfNullOrEmpty(parameter.Description.Value, entity.Description)!;
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