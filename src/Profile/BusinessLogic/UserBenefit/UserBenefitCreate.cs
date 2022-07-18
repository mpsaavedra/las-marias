namespace LasMarias.Profile.BusinessLogic.UserBenefit;

public class UserBenefitCreate
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

    public UserBenefitCreate()
    {
        Name = "Profile Create User Benefit relation Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Create an user benefit relation";
        ShortName = "Profile Create User Benefit";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.UserBenefitCreate;
    }

    public async Task<Domain.Models.UserBenefit> Run(
        Domain.DataModels.UserBenefit.UserBenefitCreateInputModel parameter,
        Func<Domain.DataModels.UserBenefit.UserBenefitCreateInputModel, Task<Domain.Models.UserBenefit>> next)
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IUserBenefitRepository>();
            _chain = _scope?.ServiceProvider.GetService<IChainOfResponsibilityService>()!;

            if (_repository == null)
            {
                throw new NullReferenceException($"User Benefit Create: Repository could not be null");
            }

            var entity = await next(parameter);


            if (entity == null)
            {
                if ((await _repository.Any(x => x.BenefitId == parameter.BenefitId && x.UserId == parameter.UserId)))
                {
                    throw new Exception($"User Benefit Create: user with id {parameter.UserId} already has a Benefit with id {parameter.BenefitId} assigned");
                }

                entity = await _repository.Create(new Domain.Models.UserBenefit
                {
                    UserId = parameter.UserId,
                    BenefitId = parameter.BenefitId
                });
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