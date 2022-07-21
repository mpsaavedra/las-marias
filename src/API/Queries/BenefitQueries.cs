namespace LasMarias.Queries;

[ExtendObjectType("Query")]
public partial class BenefitQueries
{
    [GraphQLDescription("List all available Benefit")]
    public async Task<IQueryable<Benefit>> GetBenefits(
        [Service] IChainOfResponsibilityService chain)
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
            Log.Error($"Exception while retrieving list of Benefit: {ex.FullMessage()} ");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }

    }
}