namespace LasMarias.Mutations;

[ExtendObjectType("Mutation")]
public class PriceHistoryMutations
{
    [GraphQLDescription("Deletes and PriceHistory")]
    public async Task<bool> PriceHistoryDelete(
       long id,
       [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            var deleted = await chain.ExecuteAsyncChain<long, bool>(
                EventCodes.PriceHistoryDelete, id
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