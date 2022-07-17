namespace LasMarias.Profile.Queries;

[ExtendObjectType("Query")]
public partial class BenefitQueries
{
    [GraphQLDescription("Returns a list with all available Benefits")]
    public async Task<IQueryable<Benefit>> GetBenefits(
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            Log.Debug("Benefit Query List: returns a Benefit List");
            var data = new BenefitListPayload();
            var fail = await chain.ExecuteAsyncChain<BenefitListPayload, bool>(
                EventCodes.BenefitList,
                data
            );
            return await Task.FromResult(data.Payload!);
        }
        catch (System.Exception ex)
        {
            Log.Error($"Exception while retrieving list of Benefist: {ex.FullMessage()} ");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }
}