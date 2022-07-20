namespace LasMarias.Domain.DataModels.ProductBrand;

[GraphQLDescription("returns a list of product brand relations")]
public partial class ProductBrandListPayload
{
    [GraphQLDescription("list of product brands")]
    public IQueryable<Models.ProductBrand>? Payload { get; set; }
}