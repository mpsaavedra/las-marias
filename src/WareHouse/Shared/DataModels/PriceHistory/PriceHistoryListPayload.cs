namespace LasMarias.WareHouse.Domain.DataModels.PriceHistory;

using System.Linq;
using HotChocolate;
using LasMarias.WareHouse.Domain.Models;

[GraphQLDescription("returns the list of price history relation")]
public partial class PriceHistoryListPayload
{
    [GraphQLDescription("list of price history ")]
    public IQueryable<PriceHistory>? Payload { get; set; }
}