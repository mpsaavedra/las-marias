namespace LasMarias.Profile.Queries;

[ExtendObjectType("Query")]
public partial class UserBenefitQueries
{
    public async Task<IQueryable<UserBenefit>> GetUuserBenefits(
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            Log.Debug("User Benefit Query List: returns a user/benefit relation list");
            var data = new UserBenefitListPayload();
            var fail = await chain.ExecuteAsyncChain<UserBenefitListPayload, bool>(
                EventCodes.UserBenefitList,
                data
            );
            return await Task.FromResult(data.Payload!);
        }
        catch (System.Exception ex)
        {
            Log.Error($"Exception while retrieving list of UserBenefits: {ex.FullMessage()}");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }
}