namespace LasMarias.Mutations;

[ExtendObjectType("Mutation")]
public class BenefitMutations
{
    [GraphQLDescription("Deletes and Benefit")]
    public async Task<bool> BenefitDelete(
       long id,
       [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            var deleted = await chain.ExecuteAsyncChain<long, bool>(
                EventCodes.BenefitDelete, id
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