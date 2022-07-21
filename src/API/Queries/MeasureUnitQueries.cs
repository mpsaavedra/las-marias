namespace LasMarias.Queries;

[ExtendObjectType("Query")]
public partial class MeasureUnitQueries
{
    [GraphQLDescription("List all available MeasureUnit")]
    public async Task<IQueryable<MeasureUnit>> GetMeasureUnits(
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("MeasureUnit Query List: returns a MeasureUnit List");
            var data = new MeasureUnitListPayload();
            var fail = await chain.ExecuteAsyncChain<MeasureUnitListPayload, bool>(
                EventCodes.MeasureUnitList,
                data
            );
            return await Task.FromResult(data.Payload!);
        }
        catch (System.Exception ex)
        {
            Log.Error($"Exception while retrieving list of MeasureUnit: {ex.FullMessage()} ");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }

    }
}
