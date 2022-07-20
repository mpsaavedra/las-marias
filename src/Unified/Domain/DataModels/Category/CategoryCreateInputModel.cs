namespace LasMarias.Domain.DataModels.Category;


[GraphQLDescription("basic data to create a new category")]
public class CategoryCreateInputModel
{
    [GraphQLDescription("name of the category")]
    public string Name { get; set; }

    [GraphQLDescription("unique code of this category")]
    public Optional<string> Code { get; set; }

    [GraphQLDescription("if true is available to the system")]
    public Optional<bool> Enable { get; set; }

    [GraphQLDescription("id of the parent category")]
    public Optional<long> ParentCategoryId { get; set; }
}