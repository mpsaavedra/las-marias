namespace LasMarias.BusinessLogic.Plate;

public class PlateCreate :
    IAsyncMiddleware<PlateCreateInputModel, Domain.Models.Plate>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private IPlateRepository? _repository;

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

    public PlateCreate()
    {
        Name = "Plate Create Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Creates new Plate";
        ShortName = "Plate creation";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.PlateCreate;
    }

    public async Task<Domain.Models.Plate> Run(
        PlateCreateInputModel input,
        Func<PlateCreateInputModel, Task<Domain.Models.Plate>> next
    )
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IPlateRepository>();

            if (_repository == null)
            {
                throw new NullReferenceException($"Plate Create: Repository could not be null");
            }

            Domain.Models.Plate entity = await next(input);

            if (entity == null)
            {
                var data = _repository.Mapper.Map<Domain.Models.Plate>(input);
                entity = await _repository.Create(data);
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