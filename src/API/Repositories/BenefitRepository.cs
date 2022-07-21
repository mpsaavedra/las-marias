namespace LasMarias.Repositories;

public class BenefitRepository : Repository<long, Benefit>, IBenefitRepository
{
    public BenefitRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}