namespace LasMarias.Queries;

[ExtendObjectType("Query")]
public partial class CountryQueries
{
    [GraphQLDescription("List all available Country")]
    public async Task<IQueryable<Country>> GetCountries(
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("Country Query List: returns a Country List");
            var data = new CountryListPayload();
            var fail = await chain.ExecuteAsyncChain<CountryListPayload, bool>(
                EventCodes.CountryList,
                data
            );
            return await Task.FromResult(data.Payload!);
        }
        catch (System.Exception ex)
        {
            Log.Error($"Exception while retrieving list of Country: {ex.FullMessage()} ");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }

    }
}
