namespace LasMarias.Repositories;

public partial class ProductMovementRepository : Repository<long, ProductMovement>, IProductMovementRepository
{
    public ProductMovementRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}