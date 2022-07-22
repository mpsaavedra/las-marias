namespace LasMarias.Domain.DataModels.VendorBrand;

public class VendorUpdateInputModel
{
    public Optional<long> VendorId { get; set; }

    public Optional<long> BrandId { get; set; }
}