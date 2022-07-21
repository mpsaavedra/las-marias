namespace LasMarias.Repositories;

public partial class PlateRepository : Repository<long, Plate>, IPlateRepository
{
    public PlateRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}