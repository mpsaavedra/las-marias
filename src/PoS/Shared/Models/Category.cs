namespace LasMarias.PoS.Domain.Models;

// TODO: move this entity into the restaurant service
[GraphQLDescription("Cateory of plates")]
public partial class Category : BusinessEntity<long>
{
    public Category()
    {
        ChildCategories =  new HashSet<Category>();
    }

    [GraphQLDescription("id of category")]
    public long CategoryId { get; set; }

    [GraphQLDescription("Name of category")]
    public string Name { get; set; }

    [GraphQLDescription("category description")]
    public string? Description { get; set; }

    [GraphQLDescription("if true is available in the system")]
    public bool Enable { get; set; }

    [GraphQLDescription("id of parent category")]
    public long? ParentCategoryId { get; set; }

    [GraphQLDescription("parent category")]
    public virtual Category? ParentCategory { get; set; }

    [GraphQLDescription("List of child categories")]
    public virtual ICollection<Category> ChildCategories { get; set; }

    [GraphQLDescription("plates in this category")]
    public virtual ICollection<PlateCategory> PlateCategories { get; set; }
}