namespace LasMarias.Profile.Repositories;

public class UserBenefitRepository : Repository<long, UserBenefit>, IUserBenefitRepository
{
    public UserBenefitRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}