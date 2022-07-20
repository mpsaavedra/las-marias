namespace LasMarias.Queries;

[ExtendObjectType("Query")]
public partial class MovementQueries
{
    [GraphQLDescription("List all available Movement")]
    public async Task<IQueryable<Movement>> GetMovements(
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("Movement Query List: returns a Movement List");
            var data = new MovementListPayload();
            var fail = await chain.ExecuteAsyncChain<MovementListPayload, bool>(
                EventCodes.MovementList,
                data
            );
            return await Task.FromResult(data.Payload!);
        }
        catch (System.Exception ex)
        {
            Log.Error($"Exception while retrieving list of Movement: {ex.FullMessage()} ");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }

    }
}
