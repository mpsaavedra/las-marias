namespace LasMarias.Profile.BusinessLogic.User;

public class UserAddRemoveBenefit : IAsyncMiddleware<Domain.DataModels.User.UserAddRemoveBenefit, Domain.Models.User>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private IUserRepository? _repository;

    private IBenefitRepository? _benefitRepository;

    private IUserBenefitRepository? _userBenefitRepository;

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

    public UserAddRemoveBenefit(IChainOfResponsibilityService chain)
    {
        Name = "Profile User Update Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Updates an existing User";
        ShortName = "Profile Update User";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.UserUpdate;
        _chain = chain;
    }

    public async Task<Domain.Models.User> Run(
        Domain.DataModels.User.UserAddRemoveBenefit parameter,
        Func<Domain.DataModels.User.UserAddRemoveBenefit, Task<Domain.Models.User>> next
    )
    {
        long userBenefit = 0;
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IUserRepository>();
            _userBenefitRepository = _scope?.ServiceProvider.GetService<IUserBenefitRepository>();
            _userBenefitRepository = _scope?.ServiceProvider.GetService<IUserBenefitRepository>();

            if (_repository == null || _userBenefitRepository == null || _userBenefitRepository == null)
            {
                throw new NullReferenceException($"User Add Remove Benefit: Repository could not be null");
            }

            Domain.Models.User entity = await next(parameter);

            if (entity == null)
            {
                var id = parameter.Id;
                entity = await _repository.GetOne(x => x.UserId == parameter.Id);
                if (entity == null)
                {
                    throw new Exception($"User Add/Remove Benefit: User with id {parameter.Id} was not found.");
                }

                if (!(await _benefitRepository!.Any(x => x.BenefitId == parameter.BenefitId)))
                {
                    throw new Exception($"User Add/Remove Benefit: Benefit with id {parameter.BenefitId} as not found");
                }

                switch (parameter.Operation)
                {
                    case DataOperation.Add:
                        var relation = await _chain.ExecuteAsyncChain<UserBenefitCreateInputModel, Domain.Models.UserBenefit>(
                            EventCodes.UserBenefitCreate,
                            new UserBenefitCreateInputModel { UserId = parameter.Id, BenefitId = parameter.BenefitId }
                        );
                        break;
                    case DataOperation.Remove:
                        var ub = await _userBenefitRepository.GetOne(x => x.UserId == parameter.Id && x.BenefitId == parameter.BenefitId);
                        ub.IsNullOrEmpty($"User Add/Remove Benefit: relations user-benefit with user id {parameter.Id} and benefit id {parameter.BenefitId} as not found");
                        await _chain.ExecuteAsyncChain<long, bool>(
                            EventCodes.UserBenefitDelete,
                            ub.UserBenefitId
                        );
                        break;
                }

                await _repository.Update(id, entity);
            }

            await _repository.UnitOfWork.SaveAsync();

            return await Task.FromResult(entity);
        }
        catch (Exception ex)
        {
            if (userBenefit > 0)
            {
                await _chain.ExecuteAsyncChain<long, bool>(
                    EventCodes.EmployeeDelete,
                    userBenefit
                );
            }

            Log.Error($"Exception running plugin {ShortName}: event {EventCode}: {ex.FullMessage()}");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }
}