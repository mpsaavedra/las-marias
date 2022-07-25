namespace LasMarias.BusinessLogic.UserBenefit;

public class UserBenefitUpdate : IAsyncMiddleware<UserBenefitUpdateInputModel, Domain.Models.UserBenefit>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private IUserBenefitRepository? _repository;

    private IApplicationUserRepository? _uRepository;

    private IBenefitRepository? _bRepository;

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

    public UserBenefitUpdate()
    {
        Name = "UserBenefit Update Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Updates an existing UserBenefit";
        ShortName = "Update UserBenefit";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.UserBenefitUpdate;
    }

    public async Task<Domain.Models.UserBenefit> Run(
       Domain.DataModels.UserBenefit.UserBenefitUpdateInputModel parameter,
       Func<UserBenefitUpdateInputModel, Task<Domain.Models.UserBenefit>> next
   )
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IUserBenefitRepository>();
            _uRepository = _scope?.ServiceProvider.GetService<IApplicationUserRepository>();
            _bRepository = _scope?.ServiceProvider.GetService<IBenefitRepository>();

            if (_repository == null || _uRepository == null || _bRepository == null)
            {
                throw new NullReferenceException($"UserBenefit Update: Repository could not be null");
            }

            Domain.Models.UserBenefit entity = await next(parameter);

            if (entity == null)
            {
                var id = parameter.Id;
                var data = _repository.Mapper.Map<Domain.Models.UserBenefit>(parameter);
                entity = await _repository.GetOne(x => x.UserBenefitId == id);
                if (entity == null)
                {
                    throw new Exception($"Profile UserBenefit: Entity with id {id} was not found");
                }

                if (!Is.NullOrEmpty(parameter.UserId))
                {
                    if (!(await _uRepository.Any(x => x.Id == parameter.UserId)))
                    {
                        throw new Exception($"User with id {parameter.UserId} was not found");
                    }
                    entity.UserId = parameter.UserId;
                }

                if (!Is.NullOrEmpty(parameter.BenefitId))
                {
                    if (!(await _bRepository.Any(x => x.BenefitId == parameter.BenefitId)))
                    {
                        throw new Exception($"User with id {parameter.BenefitId} was not found");
                    }
                    entity.BenefitId = parameter.BenefitId;
                }

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