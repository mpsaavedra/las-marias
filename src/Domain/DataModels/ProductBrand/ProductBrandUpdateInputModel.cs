namespace LasMarias.Domain.DataModels.ProductBrand;

public class ProductBrandUpdateInputModel
{
    public long Id { get; set; }

    public Optional<long> Productid { get; set; }

    public Optional<long> BrandId { get; set; }
}