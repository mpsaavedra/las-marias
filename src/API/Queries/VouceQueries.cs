namespace LasMarias.Queries;

[ExtendObjectType("Query")]
public partial class VouceQueries
{
    [GraphQLDescription("List all available Vouce")]
    public async Task<IQueryable<Vouce>> GetVouces(
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("Vouce Query List: returns a Vouce List");
            var data = new VouceListPayload();
            var fail = await chain.ExecuteAsyncChain<VouceListPayload, bool>(
                EventCodes.VouceList,
                data
            );
            return await Task.FromResult(data.Payload!);
        }
        catch (System.Exception ex)
        {
            Log.Error($"Exception while retrieving list of Vouce: {ex.FullMessage()} ");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }

    }
}
