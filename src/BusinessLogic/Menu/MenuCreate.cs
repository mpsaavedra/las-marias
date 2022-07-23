namespace LasMarias.BusinessLogic.Menu;

public class MenuCreate :
    IAsyncMiddleware<MenuCreateInputModel, Domain.Models.Menu>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private IMenuRepository? _repository;

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

    public MenuCreate()
    {
        Name = "Menu Create Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Creates new Menu";
        ShortName = "Menu creation";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.MenuCreate;
    }

    public async Task<Domain.Models.Menu> Run(
        MenuCreateInputModel input,
        Func<MenuCreateInputModel, Task<Domain.Models.Menu>> next
    )
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IMenuRepository>();

            if (_repository == null)
            {
                throw new NullReferenceException($"Menu Create: Repository could not be null");
            }

            Domain.Models.Menu entity = await next(input);

            if (entity == null)
            {
                var data = _repository.Mapper.Map<Domain.Models.Menu>(input);
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