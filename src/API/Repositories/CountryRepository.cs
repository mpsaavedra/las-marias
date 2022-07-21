namespace LasMarias.Repositories;

public class CountryRepository : Repository<long, Country>, ICountryRepository
{
    public CountryRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}