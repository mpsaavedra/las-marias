namespace LasMarias.Repositories;

public class VouceRepository : Repository<long, Vouce>, IVouceRepository
{
    public VouceRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}
