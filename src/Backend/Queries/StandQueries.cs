namespace LasMarias.Queries;

[ExtendObjectType("Query")]
public partial class StandQueries
{
    [GraphQLDescription("List all available Stand")]
    public async Task<IQueryable<Stand>> GetStands(
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("Stand Query List: returns a Stand List");
            var data = new StandListPayload();
            var fail = await chain.ExecuteAsyncChain<StandListPayload, bool>(
                EventCodes.StandList,
                data
            );
            return await Task.FromResult(data.Payload!);
        }
        catch (System.Exception ex)
        {
            Log.Error($"Exception while retrieving list of Stand: {ex.FullMessage()} ");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }

    }
}