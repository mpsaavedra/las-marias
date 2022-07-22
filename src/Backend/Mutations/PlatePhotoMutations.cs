namespace LasMarias.Mutations;

[ExtendObjectType("Mutation")]
public class PlatePhotoMutations
{
    [GraphQLDescription("Deletes and PlatePhoto")]
    public async Task<bool> PlatePhotoDelete(
       long id,
       [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            var deleted = await chain.ExecuteAsyncChain<long, bool>(
                EventCodes.PlatePhotoDelete, id
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