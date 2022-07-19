namespace LasMarias.PoS.Queries;

[ExtendObjectType("Query")]
[GraphQLDescription("PlateProduct queries")]
public partial class PlateProductQuery
{
    [UseFirstOrDefault]
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [GraphQLDescription("List all available PlateProduct")]
    public async Task<IQueryable<PlateProduct>> GetPlateProducts(
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            Log.Debug("Retrieving PlateProducts list");
            var data = new PlateProductListPayload();
            var fail = await chain.ExecuteAsyncChain<PlateProductListPayload, bool>(
                EventCodes.PlateProductList, data);
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