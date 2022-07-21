namespace LasMarias.Repositories;

public partial class StandRepository : Repository<long, Stand>, IStandRepository
{
    public StandRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}