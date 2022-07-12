using System.Collections.Generic;
using Orun.Domain;
using System.Text.Json.Serialization;
using HotChocolate;
using HotChocolate.Data;

namespace LasMarias.WareHouse.Domain.Models;

[GraphQLDescription("Describe the relation changes in product prices")]
public partial class PriceHistory : BusinessEntity<long>
{
    public PriceHistory()
    {
        OldPrice = 0;
        NewPrice = 0;
    }

    [GraphQLDescription("id of this product price change")]
    public long PriceHistoryId { get; set; }

    [GraphQLDescription("id of the product")]
    public long ProductId { get; set; }

    [GraphQLDescription("product which price was changed")]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual Product Product { get; set; }

    [GraphQLDescription("old product price")]
    public decimal OldPrice { get; set; }

    [GraphQLDescription("new set price")]
    public decimal NewPrice { get; set; }

    /// <summary>
    /// user id from the identity server to Know wich user change this price
    /// </summary>
    [GraphQLDescription("id of the user that change this price")]
    public string ApplicationUserId { get; set; }
}