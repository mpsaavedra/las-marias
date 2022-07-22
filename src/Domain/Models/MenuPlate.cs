namespace LasMarias.Domain.Models;

[GraphQLDescription("defines the Menu plate relations")]
public partial class MenuPlate : BusinessEntity<long>
{
    [GraphQLDescription("Id of menu plate")]
    public long MenuPlateId { get; set; }

    [GraphQLDescription("id of plate")]
    public long? PlateId { get; set; }

    [GraphQLDescription("id of menu")]
    public long? MenuId { get; set; }

    [GraphQLDescription("Plate")]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public virtual Plate? Plate { get; set; }

    [GraphQLDescription("Menu")]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public virtual Menu? Menu { get; set; }

    [GraphQLDescription("Plate cost")]
    public decimal Cost => Plate != null ? Plate.Cost : 0m;

    [GraphQLDescription("Plate selling price")]
    public decimal SellingPrice => Plate != null ? Plate.SellingPrice : 0m;

    [GraphQLDescription("Plate earning (Selling price - cost price)")]
    public decimal Earning => Plate != null ? Plate.Earning : 0m;
}