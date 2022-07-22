namespace LasMarias.Repositories;

public partial class TableRepository : Repository<long, Table>, ITableRepository
{
    public TableRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}