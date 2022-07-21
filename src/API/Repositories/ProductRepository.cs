namespace LasMarias.Repositories;

public class ProductRepository : Repository<long, Product>, IProductRepository
{
    public ProductRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}
