namespace LasMarias.Mutations;

[ExtendObjectType("Mutation")]
public class PlatePhotoMutations
{
    public async Task<Domain.Models.PlatePhoto> PlatePhotoCreate(
        PlatePhotoCreateInputModel input,
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            var entity = await chain.ExecuteAsyncChain<PlatePhotoCreateInputModel, Domain.Models.PlatePhoto>(
                EventCodes.PlatePhotoCreate, input
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

    public async Task<Domain.Models.PlatePhoto> PlatePhotoUpdate(
        PlatePhotoUpdateInputModel input,
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            var entity = await chain.ExecuteAsyncChain<PlatePhotoUpdateInputModel, Domain.Models.PlatePhoto>(
                EventCodes.PlatePhotoUpdate, input
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