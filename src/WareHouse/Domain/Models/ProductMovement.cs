using System.Collections.Generic;
using Orun.Domain;
using System.Text.Json.Serialization;
using HotChocolate.Data;

namespace LasMarias.WareHouse.Domain.Models;

public partial class ProductMovement : BusinessEntity<long>
{
    public long ProductMovementId { get; set; }

    public long ProductId { get; set; }

    public long MovementId { get; set; }

    [UseFiltering]
    [UseFiltering]
    public virtual Product Product { get; set; }

    [UseFiltering]
    [UseSorting]
    public virtual Movement Movement { get; set; }
}