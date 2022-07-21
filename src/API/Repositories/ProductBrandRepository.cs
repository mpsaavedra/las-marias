namespace LasMarias.Repositories;

public class ProductBrandRepository : Repository<long, ProductBrand>, IProductBrandRepository
{
    public ProductBrandRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}
