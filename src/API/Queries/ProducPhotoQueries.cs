namespace LasMarias.Queries;

[ExtendObjectType("Query")]
public partial class ProductPhotoQueries
{
    [GraphQLDescription("List all available ProductPhoto")]
    public async Task<IQueryable<ProductPhoto>> GetProductPhotos(
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("ProductPhoto Query List: returns a ProductPhoto List");
            var data = new ProductPhotoListPayload();
            var fail = await chain.ExecuteAsyncChain<ProductPhotoListPayload, bool>(
                EventCodes.ProductPhotoList,
                data
            );
            return await Task.FromResult(data.Payload!);
        }
        catch (System.Exception ex)
        {
            Log.Error($"Exception while retrieving list of ProductPhoto: {ex.FullMessage()} ");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }

    }
}
