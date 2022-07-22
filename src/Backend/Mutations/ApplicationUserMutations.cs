namespace LasMarias.Mutations;

[ExtendObjectType("Mutation")]
public class ApplicationUserMutations
{
    [GraphQLDescription("Deletes and ApplicationUser")]
    public async Task<bool> ApplicationUserDelete(
       long id,
       [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            var deleted = await chain.ExecuteAsyncChain<long, bool>(
                EventCodes.ApplicationUserDelete, id
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