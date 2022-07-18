namespace LasMarias.Profile.Repositories;

public partial class CountryRepository : Repository<long, Country>, ICountryRepository
{
    public CountryRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}