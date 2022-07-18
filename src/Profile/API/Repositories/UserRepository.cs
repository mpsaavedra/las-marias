namespace LasMarias.Profile.Repositories;

public class UserRepository : Repository<long, User>, IUserRepository
{
    public UserRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}