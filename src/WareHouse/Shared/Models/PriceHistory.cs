using System.Collections.Generic;
using Orun.Domain;
using System.Text.Json.Serialization;
using HotChocolate.Data;

namespace LasMarias.WareHouse.Domain.Models;

public partial class PriceHistory : BusinessEntity<long>
{
    public long PriceHistoryId { get; set; }

    public long ProductId { get; set; }

    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual Product Product { get; set; }

    public decimal OldPrice { get; set; }

    public decimal NewPrice { get; set; }

    /// <summary>
    /// user id from the identity server to Know wich user change this price
    /// </summary>
    public string ApplicationUserId { get; set; }
}