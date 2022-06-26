using System.Collections.Generic;
using Orun.Domain;
using System.Text.Json.Serialization;
using HotChocolate.Data;

namespace LasMarias.PoS.Domain.Models;

public partial class Product : BusinessEntity<long>
{
    public Product()
    {
        Attributes = new HashSet<Attribute>();
        ProductPhotos = new HashSet<ProductPhoto>();
        Categories = new HashSet<Category>();
    }

    public long ProductId { get; set; }

    public string Name { get; set; }

    public string? Decription { get; set; }

    /// <summary>
    /// price in which was buyed
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// sale price for the product
    /// <summary>
    public decimal ListPrice {get; set; }
    
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<Attribute> Attributes { get; set; }

    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<ProductPhoto> ProductPhotos { get; set; }

    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<Category> Categories { get; set; }
}