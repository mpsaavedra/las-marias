namespace LasMarias.Repositories;

public class BrandRepository : Repository<long, Brand>, IBrandRepository
{
    public BrandRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}
