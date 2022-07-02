using System.Collections.Generic;
using Orun.Domain;
using System.Text.Json.Serialization;
using HotChocolate.Data;

namespace LasMarias.WareHouse.Domain.Models;

public partial class Product : BusinessEntity<long>
{
    public Product()
    {
        Attributes = new HashSet<Attribute>();
        ProductPhotos = new HashSet<ProductPhoto>();
        Categories = new HashSet<Category>();
        PriceHistories = new HashSet<PriceHistory>();
        ProductMovements = new HashSet<ProductMovement>();
        ProductBrands = new HashSet<ProductBrand>();
        ReOrderLevel = -1;
    }

    public long ProductId { get; set; }

    public string Name { get; set; }

    public string? Decription { get; set; }

    public string? Note { get; set; }

    /// <summary>
    /// price in which was buyed
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// sale price for the product
    /// <summary>
    public decimal SellingPrice { get; set; }

    public decimal? Amount { get; set; }

    public decimal? ReOrderLevel { get; set; }

    public long MeasureUnitId { get; set; }

    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual MeasureUnit? MeasureUnit { get; set; }

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

    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<PriceHistory> PriceHistories { get; set; }

    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<ProductMovement> ProductMovements { get; set; }


    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<ProductBrand> ProductBrands { get; set; }

    /// <summary>
    /// return true if there are products available
    /// </summary>
    public bool OnStock => Amount > 0;

    /// <summary>
    /// returns true to notice that this product need to be re-order
    /// </summary>
    public bool NotifyReOrder => ReOrderLevel > -1 && Amount <= ReOrderLevel;
}