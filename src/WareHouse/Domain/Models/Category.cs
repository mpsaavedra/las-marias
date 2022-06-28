
using Orun.Domain;
using Orun.Extensions;
using HotChocolate.Data;
using System.Text.Json.Serialization;
using LasMarias.WareHouse.Domain.Repositories;

namespace LasMarias.WareHouse.Domain.Models;

/// <summary>
/// Product catetory 
/// </summary>
public partial class Category : BusinessEntity<long>
{
    public Category()
    {
        ChildCategories = new HashSet<Category>();
        Products = new HashSet<Product>();
    }

    public Category(string name)
    {
        Name = name;
        Code = name.SplitPascal("-");
    }

    public Category(string name, string code)
    {
        Name = name;
        Code = code;
    }

    public long CategoryId { get; set; }    

    public string Name { get; set; }

    public string? Code { get; set; }

    public bool Enable { get; set; }

    public long ParentCategoryId { get; set; }

    public virtual Category? ParentCategory { get; set; }

    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<Category>? ChildCategories { get; set; }

    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<Product>? Products { get; set; }
}