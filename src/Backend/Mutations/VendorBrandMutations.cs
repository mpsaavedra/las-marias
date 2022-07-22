namespace LasMarias.Mutations;

[ExtendObjectType("Mutation")]
public class VendorBrandMutations
{
    [GraphQLDescription("Deletes and VendorBrand")]
    public async Task<bool> VendorBrandDelete(
       long id,
       [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            var deleted = await chain.ExecuteAsyncChain<long, bool>(
                EventCodes.VendorBrandDelete, id
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