namespace LasMarias.Domain.Models;

/// <summary>
/// Product catetory 
/// </summary>
[GraphQLDescription("Categories used to clasify product")]
public partial class Category : BusinessEntity<long>
{
    public Category()
    {
        Name = "";
        ChildCategories = new HashSet<Category>();
        Products = new HashSet<Product>();
        Enable = true;
        PlateCategories = new HashSet<PlateCategory>();
    }

    public Category(string name)
    {
        Name = name;
        Code = name.SplitPascal("-");
        Enable = true;
        PlateCategories = new HashSet<PlateCategory>();
    }

    public Category(string name, string code)
    {
        Name = name;
        Code = code;
        Enable = true;
        PlateCategories = new HashSet<PlateCategory>();
    }

    [GraphQLDescription("id of category")]
    public long CategoryId { get; set; }

    [GraphQLDescription("category name")]
    public string Name { get; set; }

    [GraphQLDescription("code to identify this category")]
    public string? Code { get; set; }

    [GraphQLDescription("if true is available for the system")]
    public bool Enable { get; set; }

    [GraphQLDescription("id the parent caregory")]
    public long? ParentCategoryId { get; set; }

    [GraphQLDescription("parent category for this category")]
    public virtual Category? ParentCategory { get; set; }

    [GraphQLDescription("sub-category of this category")]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<Category>? ChildCategories { get; set; }

    [GraphQLDescription("list of products in this category")]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<Product>? Products { get; set; }

    [GraphQLDescription("plates in this category")]
    public virtual ICollection<PlateCategory> PlateCategories { get; set; }
}