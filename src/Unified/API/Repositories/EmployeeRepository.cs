namespace LasMarias.Repositories;

public partial class EmployeeRepository : Repository<long, Employee>
{
    public EmployeeRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}