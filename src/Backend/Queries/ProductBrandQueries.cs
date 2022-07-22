namespace LasMarias.Queries;

[ExtendObjectType("Query")]
public partial class ProductBrandQueries
{
    [GraphQLDescription("List all available ProductBrand")]
    public async Task<IQueryable<ProductBrand>> GetProductBrands(
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("ProductBrand Query List: returns a ProductBrand List");
            var data = new ProductBrandListPayload();
            var fail = await chain.ExecuteAsyncChain<ProductBrandListPayload, bool>(
                EventCodes.ProductBrandList,
                data
            );
            return await Task.FromResult(data.Payload!);
        }
        catch (System.Exception ex)
        {
            Log.Error($"Exception while retrieving list of ProductBrand: {ex.FullMessage()} ");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }

    }
}
