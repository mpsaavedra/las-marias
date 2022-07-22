namespace LasMarias.Repositories;

public partial class PlateProductRepository : Repository<long, PlateProduct>, IPlateProductRepository
{
    public PlateProductRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}