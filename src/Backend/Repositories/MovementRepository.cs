namespace LasMarias.Repositories;

public class MovementRepository : Repository<long, Movement>, IMovementRepository
{
    public MovementRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}
