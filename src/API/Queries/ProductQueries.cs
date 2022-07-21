namespace LasMarias.Queries;

[ExtendObjectType("Query")]
public partial class ProductQueries
{
    [GraphQLDescription("List all available Product")]
    public async Task<IQueryable<Product>> GetProducts(
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("Product Query List: returns a Product List");
            var data = new ProductListPayload();
            var fail = await chain.ExecuteAsyncChain<ProductListPayload, bool>(
                EventCodes.ProductList,
                data
            );
            return await Task.FromResult(data.Payload!);
        }
        catch (System.Exception ex)
        {
            Log.Error($"Exception while retrieving list of Product: {ex.FullMessage()} ");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }

    }
}
