namespace LasMarias.PoS.Queries;

[ExtendObjectType("Query")]
[GraphQLDescription("Stand queries")]
public partial class StandQuery
{
    [UsePaging]
    [UseProjection]
    [UseSorting]
    [GraphQLDescription("List all available Stand")]
    public async Task<IQueryable<Stand>> GetStands(
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            Log.Debug("Retrieving Stands list");
            var data = new StandListPayload();
            var fail = await chain.ExecuteAsyncChain<StandListPayload, bool>(
                EventCodes.StandList, data);
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