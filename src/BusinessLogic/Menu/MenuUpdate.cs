namespace LasMarias.BusinessLogic.Menu;

public class MenuUpdate : IAsyncMiddleware<MenuUpdateInputModel, Domain.Models.Menu>, IMiddlewarePlugin
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

    public MenuUpdate()
    {
        Name = "Menu Update Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Updates an existing Menu";
        ShortName = "Update Menu";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.MenuUpdate;
    }

    public async Task<Domain.Models.Menu> Run(
       Domain.DataModels.Menu.MenuUpdateInputModel parameter,
       Func<MenuUpdateInputModel, Task<Domain.Models.Menu>> next
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

            Domain.Models.Menu entity = await next(parameter);

            if (entity == null)
            {
                var id = parameter.Id;
                var data = _repository.Mapper.Map<Domain.Models.Menu>(parameter);
                entity = await _repository.GetOne(x => x.MenuId == id);
                if (entity == null)
                {
                    throw new Exception($"Profile Menu: Entity with id {id} was not found");
                }

                entity.Name = Is.ThenIfNullOrEmpty(parameter.Name.Value, entity.Name)!;
                entity.Description = Is.ThenIfNullOrEmpty(parameter.Description.Value, entity.Description)!;
                entity.Available = Is.ThenIfNullOrEmpty(parameter.Available.Value, entity.Available)!;
                entity.Offer = Is.ThenIfNullOrEmpty(parameter.Offer.Value, entity.Offer)!;
                entity.StandType = Is.ThenIfNullOrEmpty(parameter.StandType, entity.StandType)!;
                entity.SellingPrice = Is.ThenIfNullOrEmpty(parameter.SellingPrice.Value, entity.SellingPrice)!;

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