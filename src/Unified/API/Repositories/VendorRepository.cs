namespace LasMarias.Repositories;

public class VendorRepository : Repository<long, Vendor>, IVendorRepository
{
    public VendorRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}