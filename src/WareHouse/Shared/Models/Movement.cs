using System.Collections.Generic;
using Orun.Domain;
using System.Text.Json.Serialization;
using HotChocolate.Data;

namespace LasMarias.WareHouse.Domain.Models;

public partial class Movement : BusinessEntity<long>
{
    public Movement()
    {
        MovementType = MovementType.DeliverToStand;
        StandType = StandType.NotSpecified;
        ProductMovements = new HashSet<ProductMovement>();
    }

    public long MovementId { get; set; }

    /// <summary>
    /// Moved amount
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// if the movement is an entry to the warehouse then the price
    /// must be specified in order to keep a price track
    /// </summary>
    public decimal? Price { get; set; }

    public string? Description { get; set; }

    /// <summary>
    /// Id of the user that do the movement
    /// </summary>
    public string ApplicationUserId { get; set; }

    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<ProductMovement>? ProductMovements { get; set; }

    public long? VendorId { get; set; }

    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual Vendor? Vendor { get; set; }

    /// <summary>
    /// Where this product was moved
    /// </summary>
    public StandType StandType { get; set; }

    public MovementType  MovementType { get; set; }
}