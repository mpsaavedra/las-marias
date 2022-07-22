namespace LasMarias.Mutations;

[ExtendObjectType("Mutation")]
public class CategoryMutations
{
    [GraphQLDescription("Deletes and Category")]
    public async Task<bool> CategoryDelete(
       long id,
       [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            var deleted = await chain.ExecuteAsyncChain<long, bool>(
                EventCodes.CategoryDelete, id
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