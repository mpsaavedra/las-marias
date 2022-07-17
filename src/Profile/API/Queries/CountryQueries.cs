namespace LasMarias.Profile.Queries;


[ExtendObjectType("Query")]
public partial class CountryQueries
{
    [GraphQLDescription("Returns a list with all available Countrys")]
    public async Task<IQueryable<Country>> GetCountries(
        [Service] IChainOfResponsibilityService chain
    )
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
            Log.Error($"Exception while retrieving list of Countries: {ex.FullMessage()} ");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }
}