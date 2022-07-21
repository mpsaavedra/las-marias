namespace LasMarias.Repositories;

public class PriceHistoryRepository : Repository<long, PriceHistory>, IPriceHistoryRepository
{
    public PriceHistoryRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}
