namespace LasMarias.Queries;

[ExtendObjectType("Query")]
public partial class VendorBrandQueries
{
    [GraphQLDescription("List all available VendorBrand")]
    public async Task<IQueryable<VendorBrand>> GetVendorBrands(
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("VendorBrand Query List: returns a VendorBrand List");
            var data = new VendorBrandListPayload();
            var fail = await chain.ExecuteAsyncChain<VendorBrandListPayload, bool>(
                EventCodes.VendorBrandList,
                data
            );
            return await Task.FromResult(data.Payload!);
        }
        catch (System.Exception ex)
        {
            Log.Error($"Exception while retrieving list of VendorBrand: {ex.FullMessage()} ");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }

    }
}
