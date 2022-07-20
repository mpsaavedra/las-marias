namespace LasMarias.Repositories;

public class PriceHistoryRepository : Repository<long, PriceHistory>
{
    public PriceHistoryRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}
