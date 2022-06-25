
using Orun.Domain;

namespace LasMarias.PoS.Domain.Models;

/// <summary>
/// Product catetory 
/// </summary>
public partial class Category : BusinessEntity<long>
{
    public long CategoryId { get; set; }    

    public string Name { get; set; }

    public bool Enable { get; set; }

    public long ParentCategoryId { get; set; }

    public virtual Category ParentCategory { get; set; }

    public virtual ICollection<Category> ChildCategories { get; set; }

    public virtual ICollection<Product> Products { get; set; }
}