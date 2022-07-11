
using Orun.Domain;
using Orun.Extensions;
using HotChocolate;
using HotChocolate.Data;
using System.Text.Json.Serialization;

namespace LasMarias.WareHouse.Domain.Models;

/// <summary>
/// Product catetory 
/// </summary>
[GraphQLDescription("Categories used to clasify product")]
public partial class Category : BusinessEntity<long>
{
    public Category()
    {
        ChildCategories = new HashSet<Category>();
        Products = new HashSet<Product>();
        Enable = true;
    }

    public Category(string name)
    {
        Name = name;
        Code = name.SplitPascal("-");
        Enable = true;
    }

    public Category(string name, string code)
    {
        Name = name;
        Code = code;
        Enable = true;
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
}