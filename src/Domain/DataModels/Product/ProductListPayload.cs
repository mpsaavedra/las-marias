namespace LasMarias.Domain.DataModels.Product;


[GraphQLDescription("returns a list of products")]
public partial class ProductListPayload
{
    [GraphQLDescription("list of products")]
    public IQueryable<Models.Product>? Payload { get; set; }
}