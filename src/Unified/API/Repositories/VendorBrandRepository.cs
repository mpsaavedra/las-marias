namespace LasMarias.Repositories;

public class VendorBrandRepository : Repository<long, VendorBrand>
{
    public VendorBrandRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}
