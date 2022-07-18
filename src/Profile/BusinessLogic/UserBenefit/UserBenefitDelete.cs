namespace LasMarias.Profile.BusinessLogic.UserBenefit;

public class UserBenefitDelete : IAsyncMiddleware<long, bool>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private IUserBenefitRepository? _repository;

    private IChainOfResponsibilityService _chain;

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

    public UserBenefitDelete()
    {
        Name = "Profile User Benefit relation Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Deletes an user benefit relation";
        ShortName = "Profile Delete User Benefit";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.UserBenefitDelete;
    }

    public async Task<bool> Run(long id, Func<long, Task<bool>> next)
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IUserBenefitRepository>();
            _chain = _scope?.ServiceProvider.GetService<IChainOfResponsibilityService>()!;

            if (_repository == null)
            {
                throw new NullReferenceException($"User Benefit Delete: Repository could not be null");
            }

            var deleted = await next(id);


            if (!deleted)
            {
                var entity = await _repository.GetOne(x => x.UserBenefitId == id);
                if (entity == null)
                {
                    throw new Exception($"User Benefit Delete: Entity with id {id} was not found");
                }
                await _repository.Delete(entity.UserBenefitId);
            }

            await _repository.UnitOfWork.SaveAsync();

            return await Task.FromResult(true);

        }
        catch (Exception ex)
        {
            Log.Error($"Exception running plugin {ShortName}: event {EventCode}: {ex.FullMessage()}");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }
}