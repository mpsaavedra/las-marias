namespace LasMarias.Repositories;

public partial class UserBenefitRepository : Repository<long, UserBenefit>, IUserBenefitRepository
{
    public UserBenefitRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}