namespace LasMarias.Repositories;

public class VendorRepository : Repository<long, Vendor>
{
    public VendorRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}