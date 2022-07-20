namespace LasMarias.Domain.DataModels.Brand;


[GraphQLDescription("response a list of brands")]
public class BrandListPayload
{
    [GraphQLDescription("list of brands")]
    public IQueryable<Models.Brand>? Payload { get; set; }
}