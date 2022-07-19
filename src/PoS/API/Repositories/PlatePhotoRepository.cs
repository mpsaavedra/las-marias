namespace LasMarias.PoS.Repositories;

public class PlatePhotoRepository : Repository<long, PlatePhoto>, IPlatePhotoRepository
{
    public PlatePhotoRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}