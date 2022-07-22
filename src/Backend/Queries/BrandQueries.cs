namespace LasMarias.Queries;

[ExtendObjectType("Query")]
public partial class BrandQueries
{
    [GraphQLDescription("List all available Brand")]
    public async Task<IQueryable<Brand>> GetBrands(
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("Brand Query List: returns a Brand List");
            var data = new BrandListPayload();
            var fail = await chain.ExecuteAsyncChain<BrandListPayload, bool>(
                EventCodes.BrandList,
                data
            );
            return await Task.FromResult(data.Payload!);
        }
        catch (System.Exception ex)
        {
            Log.Error($"Exception while retrieving list of Brand: {ex.FullMessage()} ");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }

    }
}
