namespace LasMarias.Repositories;

public partial class EmployeeRepository : Repository<long, Employee>, IEmployeeRepository
{
    public EmployeeRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}