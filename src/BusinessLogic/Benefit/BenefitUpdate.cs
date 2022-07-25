namespace LasMarias.BusinessLogic.Benefit;

public class BenefitUpdate : IAsyncMiddleware<BenefitUpdateInputModel, Domain.Models.Benefit>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private IBenefitRepository? _repository;

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

    public BenefitUpdate()
    {
        Name = "Benefit Update Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Updates an existing Benefit";
        ShortName = "Update Benefit";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.BenefitUpdate;
    }

    public async Task<Domain.Models.Benefit> Run(
       Domain.DataModels.Benefit.BenefitUpdateInputModel parameter,
       Func<BenefitUpdateInputModel, Task<Domain.Models.Benefit>> next
   )
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IBenefitRepository>();
            if (_repository == null)
            {
                throw new NullReferenceException($"Benefit Update: Repository could not be null");
            }

            Domain.Models.Benefit entity = await next(parameter);

            if (entity == null)
            {
                var id = parameter.Id;
                var data = _repository.Mapper.Map<Domain.Models.Benefit>(parameter);
                entity = await _repository.GetOne(x => x.BenefitId == id);
                if (entity == null)
                {
                    throw new Exception($"Benefit: Entity with id {id} was not found");
                }

                entity.Name = Is.ThenIfNullOrEmpty(parameter.Name.Value, entity.Name)!;
                entity.Description = Is.ThenIfNullOrEmpty(parameter.Description.Value, entity.Description)!;
                entity.DisccountAmount = Is.ThenIfNullOrEmpty(parameter.DisccountAmount.Value, entity.Description)!;
                entity.Over = Is.ThenIfNullOrEmpty(parameter.Over.Value, entity.Over)!;

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