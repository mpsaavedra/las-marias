namespace LasMarias.BusinessLogic.MenuPlate;

public class MenuPlateCreate :
    IAsyncMiddleware<MenuPlateCreateInputModel, Domain.Models.MenuPlate>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private IMenuPlateRepository? _repository;

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

    public MenuPlateCreate()
    {
        Name = "MenuPlate Create Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Creates new MenuPlate";
        ShortName = "MenuPlate creation";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.MenuPlateCreate;
    }

    public async Task<Domain.Models.MenuPlate> Run(
        MenuPlateCreateInputModel input,
        Func<MenuPlateCreateInputModel, Task<Domain.Models.MenuPlate>> next
    )
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IMenuPlateRepository>();

            if (_repository == null)
            {
                throw new NullReferenceException($"MenuPlate Create: Repository could not be null");
            }

            Domain.Models.MenuPlate entity = await next(input);

            if (entity == null)
            {
                var data = _repository.Mapper.Map<Domain.Models.MenuPlate>(input);
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