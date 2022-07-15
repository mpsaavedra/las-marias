namespace LasMarias.WareHouse.Domain.Models;

[GraphQLDescription("Product movement data, where amount, price and many other information")]
public partial class Movement : BusinessEntity<long>
{
    public Movement()
    {
        MovementType = MovementType.DeliverToStand;
        StandType = StandType.NotSpecified;
        ProductMovements = new HashSet<ProductMovement>();
        ApplicationUserId = "";
    }

    public Movement(string applicationUserId, MovementType movementType, StandType standType)
    {
        MovementType = movementType;
        StandType = standType;
        ProductMovements = new HashSet<ProductMovement>();
        ApplicationUserId = applicationUserId;
    }

    [GraphQLDescription("id of the movement")]
    public long MovementId { get; set; }

    /// <summary>
    /// Moved amount
    /// </summary>
    [GraphQLDescription("amount of products in the movement")]
    public decimal Amount { get; set; }

    /// <summary>
    /// if the movement is an entry to the warehouse then the price
    /// must be specified in order to keep a price track
    /// </summary>
    [GraphQLDescription("price of product in this movement, that could be different from the registered price")]
    public decimal? Price { get; set; }

    [GraphQLDescription("Description of the movement")]
    public string? Description { get; set; }

    /// <summary>
    /// Id of the user that do the movement
    /// </summary>
    [GraphQLDescription("id of user that made the movement")]
    public string ApplicationUserId { get; set; }

    [GraphQLDescription("list of relations of movement of product")]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<ProductMovement>? ProductMovements { get; set; }

    [GraphQLDescription("id of the vendor")]
    public long? VendorId { get; set; }

    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    [GraphQLDescription("if movement is an entrance/exit vendor could be specified")]
    public virtual Vendor? Vendor { get; set; }

    /// <summary>
    /// Where this product was moved
    /// </summary>
    [GraphQLDescription("Stand this product was moved to")]
    public StandType StandType { get; set; }

    [GraphQLDescription("Type of movement")]
    public MovementType  MovementType { get; set; }
}