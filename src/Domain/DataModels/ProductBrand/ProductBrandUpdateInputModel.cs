namespace LasMarias.Domain.DataModels.ProductBrand;

public class ProductBrandUpdateInputModel
{
    public Optional<long> Productid { get; set; }

    public Optional<long> BrandId { get; set; }
}