namespace LasMarias.PoS.Repositories;

public class CategoryRepository : Repository<long, Category>, ICategoryRepository
{
    public CategoryRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}