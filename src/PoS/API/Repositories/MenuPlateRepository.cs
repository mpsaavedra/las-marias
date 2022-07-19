namespace LasMarias.PoS.Repositories;

public class MenuPlateRepository : Repository<long, MenuPlate>, IMenuPlateRepository
{
    public MenuPlateRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}