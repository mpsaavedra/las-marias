namespace LasMarias.Queries;

[ExtendObjectType("Query")]
public partial class PlateQueries
{
    [GraphQLDescription("List all available Plate")]
    public async Task<IQueryable<Plate>> GetPlates(
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("Plate Query List: returns a Plate List");
            var data = new PlateListPayload();
            var fail = await chain.ExecuteAsyncChain<PlateListPayload, bool>(
                EventCodes.PlateList,
                data
            );
            return await Task.FromResult(data.Payload!);
        }
        catch (System.Exception ex)
        {
            Log.Error($"Exception while retrieving list of Plate: {ex.FullMessage()} ");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }

    }
}