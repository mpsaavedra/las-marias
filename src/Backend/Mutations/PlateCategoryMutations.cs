namespace LasMarias.Mutations;

[ExtendObjectType("Mutation")]
public class PlateCategoryMutations
{
    [GraphQLDescription("Deletes and PlateCategory")]
    public async Task<bool> PlateCategoryDelete(
       long id,
       [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            var deleted = await chain.ExecuteAsyncChain<long, bool>(
                EventCodes.PlateCategoryDelete, id
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