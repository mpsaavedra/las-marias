namespace LasMarias.Domain.DataModels.VendorBrand;

public class VendorBrandUpdateInputModel
{
    public long Id { get; set; }

    public Optional<long> VendorId { get; set; }

    public Optional<long> BrandId { get; set; }
}