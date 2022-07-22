namespace LasMarias.Domain.Models;

[GraphQLDescription("describe the product")]
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
        Name = "";
    }

    [GraphQLDescription("id of the product")]
    public long ProductId { get; set; }

    [GraphQLDescription("name of product, as human understandable as possible")]
    public string Name { get; set; }

    [GraphQLDescription("description of the product")]
    public string? Description { get; set; }

    [GraphQLDescription("simple note about this product that is not included in the description, like it will expire in 48hrs or else")]
    public string? Note { get; set; }

    /// <summary>
    /// price in which was buyed
    /// </summary>
    [GraphQLDescription("price this product was bought from the vendor")]
    public decimal Price { get; set; }

    /// <summary>
    /// sale price for the product
    /// <summary>
    [GraphQLDescription("selling price of this product, used to calculate earnings")]
    public decimal SellingPrice { get; set; }

    /// <summary>
    /// existence on the warehouse
    /// </summary>
    [GraphQLDescription("amount of products in existence")]
    public decimal? Amount { get; set; }

    [GraphQLDescription("reorder level if bigger than -1 it will be used to send a re-order notification to manager")]
    public decimal? ReOrderLevel { get; set; }

    [GraphQLDescription("id of the measure unit")]
    public long? MeasureUnitId { get; set; }

    [GraphQLDescription("Measure unit this product is measured normally")]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual MeasureUnit? MeasureUnit { get; set; }

    [GraphQLDescription("list of attributes of this product. this allow to fine grain filter the products, for example pork meat 2kg bag and pork meat 1kg meat.")]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<Attribute>? Attributes { get; set; }

    [GraphQLDescription("lilst of relation of product photos")]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<ProductPhoto>? ProductPhotos { get; set; }

    [GraphQLDescription("list of categories")]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<Category>? Categories { get; set; }

    [GraphQLDescription("list all price changes")]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<PriceHistory>? PriceHistories { get; set; }

    [GraphQLDescription("list of product movements, this relation trace all movements")]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<ProductMovement>? ProductMovements { get; set; }

    [GraphQLDescription("brands list of this product, more than one if product could be produced by more than one brand, for example toothpaste, Colgate and SpringFlavor. Only one is normal in common cases")]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<ProductBrand>? ProductBrands { get; set; }

    /// <summary>
    /// return true if there are products available
    /// </summary>
    [GraphQLDescription("true if theres any product available on stock")]
    public bool OnStock => Amount > 0;

    /// <summary>
    /// returns true to notice that this product need to be re-order
    /// </summary>
    [GraphQLDescription("returns true or false if product need to reorder, uses ReOrderLevel and Amount property to return the value")]
    public bool NotifyReOrder => ReOrderLevel > -1 && Amount <= ReOrderLevel;
}