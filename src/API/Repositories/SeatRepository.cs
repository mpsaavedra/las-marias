namespace LasMarias.Repositories;

public partial class SeatRepository : Repository<long, Seat>, ISeatRepository
{
    public SeatRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}