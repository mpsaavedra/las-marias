namespace LasMarias.Repositories;

public class MovementRepository : Repository<long, Movement>
{
    public MovementRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}
