namespace LasMarias.Mutations;

[ExtendObjectType("Mutation")]
public class UserBenefitMutations
{
    [GraphQLDescription("Deletes and UserBenefit")]
    public async Task<bool> UserBenefitDelete(
       long id,
       [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            var deleted = await chain.ExecuteAsyncChain<long, bool>(
                EventCodes.UserBenefitDelete, id
            );
            return await Task.FromResult(deleted);
        }
        catch (Exception ex)
        {
            Log.Error($"Exception has occur while creating benefit: {ex.FullMessage()}");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }

}