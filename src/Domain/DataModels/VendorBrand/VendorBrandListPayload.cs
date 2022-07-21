namespace LasMarias.Domain.DataModels.VendorBrand;

[GraphQLDescription("returns a list vendor brands relations")]
public partial class VendorBrandListPayload
{
    [GraphQLDescription("list of vendor brand")]
    public IQueryable<Models.VendorBrand>? Payload { get; set; }
}