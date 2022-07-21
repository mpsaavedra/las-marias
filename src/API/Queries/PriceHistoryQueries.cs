namespace LasMarias.Queries;

[ExtendObjectType("Query")]
public partial class PriceHistoryQueries
{
    [GraphQLDescription("List all available PriceHistory")]
    public async Task<IQueryable<PriceHistory>> GetPriceHistorys(
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("PriceHistory Query List: returns a PriceHistory List");
            var data = new PriceHistoryListPayload();
            var fail = await chain.ExecuteAsyncChain<PriceHistoryListPayload, bool>(
                EventCodes.PriceHistoryList,
                data
            );
            return await Task.FromResult(data.Payload!);
        }
        catch (System.Exception ex)
        {
            Log.Error($"Exception while retrieving list of PriceHistory: {ex.FullMessage()} ");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }

    }
}
