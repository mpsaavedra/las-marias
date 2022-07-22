namespace LasMarias.Mutations;

[ExtendObjectType("Mutation")]
public class ProductPhotoMutations
{
    public async Task<Domain.Models.ProductPhoto> ProductPhotoCreate(
        ProductPhotoCreateInputModel input,
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            var entity = await chain.ExecuteAsyncChain<ProductPhotoCreateInputModel, Domain.Models.ProductPhoto>(
                EventCodes.ProductPhotoCreate, input
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

    public async Task<Domain.Models.ProductPhoto> ProductPhotoUpdate(
        ProductPhotoUpdateInputModel input,
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            var entity = await chain.ExecuteAsyncChain<ProductPhotoUpdateInputModel, Domain.Models.ProductPhoto>(
                EventCodes.ProductPhotoUpdate, input
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


    [GraphQLDescription("Deletes and ProductPhoto")]
    public async Task<bool> ProductPhotoDelete(
       long id,
       [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            var deleted = await chain.ExecuteAsyncChain<long, bool>(
                EventCodes.ProductPhotoDelete, id
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