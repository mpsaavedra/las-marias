namespace LasMarias.PoS.Repositories;

public class PlateRepository : Repository<long, Plate>, IPlateRepository
{
    public PlateRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}