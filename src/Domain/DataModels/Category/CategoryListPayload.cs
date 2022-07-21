namespace LasMarias.Domain.DataModels.Category;

[GraphQLDescription("returns the list of categories")]
public partial class CategoryListPayload
{
    [GraphQLDescription("list of category")]
    public IQueryable<Models.Category>? Payload { get; set; }
}