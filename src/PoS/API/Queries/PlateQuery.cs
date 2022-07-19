namespace LasMarias.PoS.Queries;

[ExtendObjectType("Query")]
[GraphQLDescription("Plate queries")]
public partial class PlateQuery
{
    [UseFirstOrDefault]
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [GraphQLDescription("List all available Plate")]
    public async Task<IQueryable<Plate>> GetPlates(
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            Log.Debug("Retrieving Plates list");
            var data = new PlateListPayload();
            var fail = await chain.ExecuteAsyncChain<PlateListPayload, bool>(
                EventCodes.PlateList, data);
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