namespace LasMarias.Queries;

[ExtendObjectType("Query")]
public partial class CategoryQueries
{
    [GraphQLDescription("List all available Category")]
    public async Task<IQueryable<Category>> GetCategorys(
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("Category Query List: returns a Category List");
            var data = new CategoryListPayload();
            var fail = await chain.ExecuteAsyncChain<CategoryListPayload, bool>(
                EventCodes.CategoryList,
                data
            );
            return await Task.FromResult(data.Payload!);
        }
        catch (System.Exception ex)
        {
            Log.Error($"Exception while retrieving list of Category: {ex.FullMessage()} ");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }

    }
}
