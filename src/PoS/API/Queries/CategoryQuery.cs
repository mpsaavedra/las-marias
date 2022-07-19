namespace LasMarias.PoS.Queries;

[ExtendObjectType("Query")]
[GraphQLDescription("Category queries")]
public partial class CategoryQuery
{
    [UseFirstOrDefault]
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [GraphQLDescription("List all available Category")]
    public async Task<IQueryable<Category>> GetCategories(
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            Log.Debug("Retrieving Categories list");
            var data = new CategoryListPayload();
            var fail = await chain.ExecuteAsyncChain<CategoryListPayload, bool>(
                EventCodes.CategoryList, data);
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