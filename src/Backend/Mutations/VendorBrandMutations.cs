namespace LasMarias.Mutations;

[ExtendObjectType("Mutation")]
public class VendorBrandMutations
{
    public async Task<Domain.Models.VendorBrand> VendorBrandCreate(
        VendorBrandCreateInputModel input,
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            var entity = await chain.ExecuteAsyncChain<VendorBrandCreateInputModel, Domain.Models.VendorBrand>(
                EventCodes.VendorBrandCreate, input
            );
            return await Task.FromResult(entity);
        }
        catch (System.Exception ex)
        {
            Log.Error($"Exception has occur while creating benefit: {ex.FullMessage()}");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }

    public async Task<Domain.Models.VendorBrand> VendorBrandUpdate(
        VendorBrandUpdateInputModel input,
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            var entity = await chain.ExecuteAsyncChain<VendorBrandUpdateInputModel, Domain.Models.VendorBrand>(
                EventCodes.VendorBrandUpdate, input
            );
            return await Task.FromResult(entity);
        }
        catch (System.Exception ex)
        {
            Log.Error($"Exception has occur while creating benefit: {ex.FullMessage()}");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }


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