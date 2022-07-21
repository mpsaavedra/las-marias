namespace LasMarias.Repositories;

public class ApplicationUserRepository : Repository<string, ApplicationUser>, IApplicationUserRepository
{
    public ApplicationUserRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}