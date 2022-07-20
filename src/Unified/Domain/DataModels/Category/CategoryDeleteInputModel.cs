namespace LasMarias.Domain.DataModels.Category;


[GraphQLDescription("basc data of the category to delete")]
public class CategoryDeleteInputModel
{
    [GraphQLDescription("id of the category to delete")]
    public long Id { get; set; }
}