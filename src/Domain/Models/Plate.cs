namespace LasMarias.Domain.Models;

// TODO: move this entity into the restaurant service
[GraphQLDescription("A plate offer in the menu. it could also refer to drinks or else")]
public partial class Plate : BusinessEntity<long>
{
    public Plate()
    {
        PlateProducts = new HashSet<PlateProduct>();
        PlatePhotos = new HashSet<PlatePhoto>();
        SellingPrice = 0m;
        Name = "";
        MenuPlates = new HashSet<MenuPlate>();
        SellingPrice = 0m;
        Available = true;
    }

    [GraphQLDescription("Id of plate")]
    public long PlateId { get; set; }

    [GraphQLDescription("Plate's name")]
    public string Name { get; set; }

    [GraphQLDescription("Description")]
    public string? Description { get; set; }

    [GraphQLDescription("Recipe explaining how the plate is prepared, plates could also refer to drinks or else")]
    public string? Recipe { get; set; }

    [GraphQLDescription("list of plate products involve in plate creation")]
    public virtual ICollection<PlateProduct>? PlateProducts { get; set; }

    [GraphQLDescription("list of relation menu plates meaning")]
    public virtual ICollection<MenuPlate>? MenuPlates { get; set; }

    [GraphQLDescription("price to sale the plate")]
    public decimal SellingPrice { get; set; }

    [GraphQLDescription("if true is available")]
    public bool Available { get; set; }

    [GraphQLDescription("plate categories")]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public virtual ICollection<PlateCategory>? PlateCategories { get; set; }

    [GraphQLDescription("lilst of relation of plate photos")]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<PlatePhoto>? PlatePhotos { get; set; }

    [GraphQLDescription("Cost price of plate using product cost price")]
    public decimal Cost
    {
        get => PlateProducts != null ? PlateProducts.Sum(x => x.Product!.Price * x.Amount) : 0;
    }

    [GraphQLDescription("Plate Earning (Selling price - Cost price)")]
    public decimal Earning => SellingPrice - Cost;
}