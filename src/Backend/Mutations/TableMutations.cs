namespace LasMarias.Mutations;

[ExtendObjectType("Mutation")]
public class TableMutations
{
    public async Task<Domain.Models.Table> TableCreate(
        TableCreateInputModel input,
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            var entity = await chain.ExecuteAsyncChain<TableCreateInputModel, Domain.Models.Table>(
                EventCodes.TableCreate, input
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

    public async Task<Domain.Models.Table> TableUpdate(
        TableUpdateInputModel input,
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            var entity = await chain.ExecuteAsyncChain<TableUpdateInputModel, Domain.Models.Table>(
                EventCodes.TableUpdate, input
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


    [GraphQLDescription("Deletes and Table")]
    public async Task<bool> TableDelete(
       long id,
       [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            var deleted = await chain.ExecuteAsyncChain<long, bool>(
                EventCodes.TableDelete, id
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