namespace LasMarias.PoS.Repositories;

public class MenuRepository : Repository<long, Menu>, IMenuRepository
{
    public MenuRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}