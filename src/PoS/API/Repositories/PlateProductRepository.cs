namespace LasMarias.PoS.Repositories;

public class PlateProductRepository : Repository<long, PlateProduct>, IPlateProductRepository
{
    public PlateProductRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}