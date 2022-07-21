namespace LasMarias.Queries;

[ExtendObjectType("Query")]
public partial class VendorQueries
{
    [GraphQLDescription("List all available Vendor")]
    public async Task<IQueryable<Vendor>> GetVendors(
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("Vendor Query List: returns a Vendor List");
            var data = new VendorListPayload();
            var fail = await chain.ExecuteAsyncChain<VendorListPayload, bool>(
                EventCodes.VendorList,
                data
            );
            return await Task.FromResult(data.Payload!);
        }
        catch (System.Exception ex)
        {
            Log.Error($"Exception while retrieving list of Vendor: {ex.FullMessage()} ");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }

    }
}
