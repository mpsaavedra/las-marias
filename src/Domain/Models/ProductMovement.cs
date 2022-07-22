namespace LasMarias.Domain.Models;

[GraphQLDescription("Describe a product movement relation")]
public partial class ProductMovement : BusinessEntity<long>
{
    [GraphQLDescription("id of product movement")]
    public long ProductMovementId { get; set; }

    [GraphQLDescription("product id")]
    public long ProductId { get; set; }

    [GraphQLDescription("movement id")]
    public long MovementId { get; set; }

    [GraphQLDescription("vouce's id")]
    public long VouceId { get; set; }

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    [GraphQLDescription("Product data")]
    public virtual Product? Product { get; set; }

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    [GraphQLDescription("Movement data")]
    public virtual Movement? Movement { get; set; }

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    [GraphQLDescription("vouce object")]
    public virtual Vouce? Vouce { get; set; }
}