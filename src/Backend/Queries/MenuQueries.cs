namespace LasMarias.Queries;

[ExtendObjectType("Query")]
public partial class MenuQueries
{
    [GraphQLDescription("List all available Menu")]
    public async Task<IQueryable<Menu>> GetMenus(
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("Menu Query List: returns a Menu List");
            var data = new MenuListPayload();
            var fail = await chain.ExecuteAsyncChain<MenuListPayload, bool>(
                EventCodes.MenuList,
                data
            );
            return await Task.FromResult(data.Payload!);
        }
        catch (System.Exception ex)
        {
            Log.Error($"Exception while retrieving list of Menu: {ex.FullMessage()} ");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }

    }
}