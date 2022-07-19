namespace LasMarias.PoS.Queries;

[ExtendObjectType("Query")]
[GraphQLDescription("Menu queries")]
public partial class MenuQuery
{
    [UseFirstOrDefault]
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [GraphQLDescription("List all available Menu")]
    public async Task<IQueryable<Menu>> GetMenus(
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            Log.Debug("Retrieving Menus list");
            var data = new MenuListPayload();
            var fail = await chain.ExecuteAsyncChain<MenuListPayload, bool>(
                EventCodes.MenuList, data);
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