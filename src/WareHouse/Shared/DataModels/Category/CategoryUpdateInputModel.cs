namespace LasMarias.WareHouse.Domain.DataModels.Category;

using HotChocolate;

[GraphQLDescription("basic data of the category to update")]
public class CategoryUpdateInputModel
{
    [GraphQLDescription("id of the category to udate")]
    public long Id { get; set; }
    
    [GraphQLDescription("name of the category")]
    public Optional<string> Name { get; set; }

    [GraphQLDescription("code of the category")]
    public Optional<string> Code { get; set; }

    [GraphQLDescription("fi true category is available in the system")]
    public Optional<bool> Enable { get; set; }

    [GraphQLDescription("id of the parent category")]
    public Optional<long> ParentCagetoryId { get; set; }
}