namespace LasMarias.Profile.Repositories;

public partial class BenefitRepository : Repository<long, Benefit>, IBenefitRepository
{
    public BenefitRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}