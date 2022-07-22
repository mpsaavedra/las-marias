namespace LasMarias.Queries;

[ExtendObjectType("Query")]
public partial class UserBenefitQueries
{
    [GraphQLDescription("List all available UserBenefit")]
    public async Task<IQueryable<UserBenefit>> GetUserBenefits(
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("UserBenefit Query List: returns a UserBenefit List");
            var data = new UserBenefitListPayload();
            var fail = await chain.ExecuteAsyncChain<UserBenefitListPayload, bool>(
                EventCodes.UserBenefitList,
                data
            );
            return await Task.FromResult(data.Payload!);
        }
        catch (System.Exception ex)
        {
            Log.Error($"Exception while retrieving list of UserBenefit: {ex.FullMessage()} ");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }

    }
}