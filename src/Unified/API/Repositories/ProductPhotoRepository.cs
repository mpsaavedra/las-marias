namespace LasMarias.Repositories;

public class ProductPhotoRepository : Repository<long, ProductPhoto>, IProductPhotoRepository
{
    public ProductPhotoRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}
