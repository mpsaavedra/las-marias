namespace LasMarias.Domain.Models;

[GraphQLDescription("describes a plate product relations")]
public partial class PlateProduct : BusinessEntity<long>
{
    public PlateProduct()
    {
        Amount = 0m;
    }

    [GraphQLDescription("id of plate product")]
    public long PlateProductId { get; set; }

    [GraphQLDescription("id of plate")]
    public long? PlateId { get; set; }

    [GraphQLDescription("id of product")]
    public long? ProductId { get; set; }

    [GraphQLDescription("Plate")]
    public virtual Plate? Plate { get; set; }

    // TODO: retrieve the product from the warehouse using the product Id
    [GraphQLDescription("Product to use in plate")]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public virtual Product? Product { get; }

    [GraphQLDescription("Amount of product in plate")]
    public decimal Amount { get; set; }

    [GraphQLDescription("Id of measure unit")]
    public long? MeasureUnitId { get; set; }

    // TODO: retrieve the measure unit from the warehouse using the measureunit Id
    [GraphQLDescription("Measure unit the product is measure to use in plate")]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public virtual MeasureUnit? MeasureUnit { get; }
}