namespace LasMarias.PoS.Queries;

[ExtendObjectType("Query")]
[GraphQLDescription("MenuPlate queries")]
public partial class MenuPlateQuery
{
    [UseFirstOrDefault]
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [GraphQLDescription("List all available MenuPlate")]
    public async Task<IQueryable<MenuPlate>> GetMenuPlates(
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            Log.Debug("Retrieving MenuPlates list");
            var data = new MenuPlateListPayload();
            var fail = await chain.ExecuteAsyncChain<MenuPlateListPayload, bool>(
                EventCodes.MenuPlateList, data);
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