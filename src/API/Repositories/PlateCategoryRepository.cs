namespace LasMarias.Repositories;

public partial class PlateCategoryRepository : Repository<long, PlateCategory>, IPlateCategoryRepository
{
    public PlateCategoryRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}