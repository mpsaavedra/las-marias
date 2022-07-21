namespace LasMarias.Domain.DataModels.PriceHistory;

[GraphQLDescription("returns the list of price history relation")]
public partial class PriceHistoryListPayload
{
    [GraphQLDescription("list of price history ")]
    public IQueryable<Models.PriceHistory>? Payload { get; set; }
}