namespace LasMarias.BusinessLogic.AttributeName;

public class AttributeNameCreate :
    IAsyncMiddleware<AttributeNameCreateInputModel, Domain.Models.AttributeName>, IMiddlewarePlugin
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

    public AttributeNameCreate()
    {
        Name = "AttributeName Create Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Creates new attributeName";
        ShortName = "AttributeName creation";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.AttributeNameCreate;
    }

    public async Task<Domain.Models.AttributeName> Run(
        AttributeNameCreateInputModel input,
        Func<AttributeNameCreateInputModel, Task<Domain.Models.AttributeName>> next
    )
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IAttributeNameRepository>();

            if (_repository == null)
            {
                throw new NullReferenceException($"Benefit Create: Repository could not be null");
            }

            Domain.Models.AttributeName entity = await next(input);

            if (entity == null)
            {
                var data = _repository.Mapper.Map<Domain.Models.AttributeName>(input);
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