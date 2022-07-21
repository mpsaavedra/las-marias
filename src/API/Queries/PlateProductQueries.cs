namespace LasMarias.Queries;

[ExtendObjectType("Query")]
public partial class PlateProductQueries
{
    [GraphQLDescription("List all available PlateProduct")]
    public async Task<IQueryable<PlateProduct>> GetPlateProducts(
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("PlateProduct Query List: returns a PlateProduct List");
            var data = new PlateProductListPayload();
            var fail = await chain.ExecuteAsyncChain<PlateProductListPayload, bool>(
                EventCodes.PlateProductList,
                data
            );
            return await Task.FromResult(data.Payload!);
        }
        catch (System.Exception ex)
        {
            Log.Error($"Exception while retrieving list of PlateProduct: {ex.FullMessage()} ");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }

    }
}