namespace LasMarias.Repositories;

public partial class PlatePhotoRepository : Repository<long, PlatePhoto>, IPlatePhotoRepository
{
    public PlatePhotoRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}