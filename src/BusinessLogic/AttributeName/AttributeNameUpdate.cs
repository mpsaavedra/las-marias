namespace LasMarias.BusinessLogic.AttributeName;

public class AttributeNameUpdate : IAsyncMiddleware<AttributeNameUpdateInputModel, Domain.Models.AttributeName>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private IAttributeNameRepository? _repository;

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

    public AttributeNameUpdate()
    {
        Name = "AttributeName Update Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Updates an existing AttributeName";
        ShortName = "Update AttributeName";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.AttributeNameUpdate;
    }

    public async Task<Domain.Models.AttributeName> Run(
       Domain.DataModels.AttributeName.AttributeNameUpdateInputModel parameter,
       Func<AttributeNameUpdateInputModel, Task<Domain.Models.AttributeName>> next
   )
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IAttributeNameRepository>();
            if (_repository == null)
            {
                throw new NullReferenceException($"AttributeName Update: Repository could not be null");
            }

            Domain.Models.AttributeName entity = await next(parameter);

            if (entity == null)
            {
                var id = parameter.Id;
                var data = _repository.Mapper.Map<Domain.Models.AttributeName>(parameter);
                entity = await _repository.GetOne(x => x.AttributeNameId == id);
                if (entity == null)
                {
                    throw new Exception($"AttributeName: Entity with id {id} was not found");
                }

                entity.Name = Is.ThenIfNullOrEmpty(parameter.Name.Value, entity.Name)!;
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