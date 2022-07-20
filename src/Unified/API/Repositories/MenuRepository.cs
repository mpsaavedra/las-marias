namespace LasMarias.Repositories;

public partial class MenuRepository : Repository<long, Menu>, IMenuRepository
{
    public MenuRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}