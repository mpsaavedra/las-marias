namespace LasMarias.PoS.Queries;

[ExtendObjectType("Query")]
[GraphQLDescription("Seat queries")]
public partial class SeatQuery
{
    [UseFirstOrDefault]
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [GraphQLDescription("List all available Seat")]
    public async Task<IQueryable<Seat>> GetSeats(
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            Log.Debug("Retrieving Seats list");
            var data = new SeatListPayload();
            var fail = await chain.ExecuteAsyncChain<SeatListPayload, bool>(
                EventCodes.SeatList, data);
            return await Task.FromResult(data.Payload!);
        }
        catch (Exception ex)
        {
            Log.Error($"An exception occurs while listing Catagory: {ex.FullMessage()}");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }
}