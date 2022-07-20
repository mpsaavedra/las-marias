namespace LasMarias.Repositories;

public class VouceRepository : Repository<long, Vouce>
{
    public VouceRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}
