namespace LasMarias.Domain.DataModels.ProductPhoto;

[GraphQLDescription("returns a list of product photo relations")]
public partial class ProductPhotoListPayload
{
    [GraphQLDescription("list of product photos")]
    public IQueryable<Models.ProductPhoto>? Payload { get; set; }
}