namespace LasMarias.Queries;

[ExtendObjectType("Query")]
public partial class SeatQueries
{
    [GraphQLDescription("List all available Seat")]
    public async Task<IQueryable<Seat>> GetSeats(
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("Seat Query List: returns a Seat List");
            var data = new SeatListPayload();
            var fail = await chain.ExecuteAsyncChain<SeatListPayload, bool>(
                EventCodes.SeatList,
                data
            );
            return await Task.FromResult(data.Payload!);
        }
        catch (System.Exception ex)
        {
            Log.Error($"Exception while retrieving list of Seat: {ex.FullMessage()} ");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }

    }
}