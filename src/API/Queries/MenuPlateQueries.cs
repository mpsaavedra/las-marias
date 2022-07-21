namespace LasMarias.Queries;

[ExtendObjectType("Query")]
public partial class MenuPlateQueries
{
    [GraphQLDescription("List all available MenuPlate")]
    public async Task<IQueryable<MenuPlate>> GetMenuPlates(
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("MenuPlate Query List: returns a MenuPlate List");
            var data = new MenuPlateListPayload();
            var fail = await chain.ExecuteAsyncChain<MenuPlateListPayload, bool>(
                EventCodes.MenuPlateList,
                data
            );
            return await Task.FromResult(data.Payload!);
        }
        catch (System.Exception ex)
        {
            Log.Error($"Exception while retrieving list of MenuPlate: {ex.FullMessage()} ");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }

    }
}