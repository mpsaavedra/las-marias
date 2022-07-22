namespace LasMarias.Queries;

[ExtendObjectType("Query")]
public partial class PlateCategoryQueries
{
    [GraphQLDescription("List all available PlateCategory")]
    public async Task<IQueryable<PlateCategory>> GetPlateCategorys(
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("PlateCategory Query List: returns a PlateCategory List");
            var data = new PlateCategoryListPayload();
            var fail = await chain.ExecuteAsyncChain<PlateCategoryListPayload, bool>(
                EventCodes.PlateCategoryList,
                data
            );
            return await Task.FromResult(data.Payload!);
        }
        catch (System.Exception ex)
        {
            Log.Error($"Exception while retrieving list of PlateCategory: {ex.FullMessage()} ");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }

    }
}