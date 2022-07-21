namespace LasMarias.Repositories;

public class VendorBrandRepository : Repository<long, VendorBrand>, IVendorBrandRepository
{
    public VendorBrandRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}
