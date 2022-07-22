namespace LasMarias.Mutations;

[ExtendObjectType("Mutation")]
public class MovementMutations
{
    public async Task<Domain.Models.Movement> MovementCreate(
        MovementCreateInputModel input,
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            var entity = await chain.ExecuteAsyncChain<MovementCreateInputModel, Domain.Models.Movement>(
                EventCodes.MovementCreate, input
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

    public async Task<Domain.Models.Movement> MovementUpdate(
        MovementUpdateInputModel input,
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            var entity = await chain.ExecuteAsyncChain<MovementUpdateInputModel, Domain.Models.Movement>(
                EventCodes.MovementUpdate, input
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


    [GraphQLDescription("Deletes and Movement")]
    public async Task<bool> MovementDelete(
       long id,
       [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            var deleted = await chain.ExecuteAsyncChain<long, bool>(
                EventCodes.MovementDelete, id
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