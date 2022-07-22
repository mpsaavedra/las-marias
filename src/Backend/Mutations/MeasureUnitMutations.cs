namespace LasMarias.Mutations;

[ExtendObjectType("Mutation")]
public class MeasureUnitMutations
{
    public async Task<Domain.Models.MeasureUnit> MeasureUnitCreate(
        MeasureUnitCreateInputModel input,
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            var entity = await chain.ExecuteAsyncChain<MeasureUnitCreateInputModel, Domain.Models.MeasureUnit>(
                EventCodes.MeasureUnitCreate, input
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

    public async Task<Domain.Models.MeasureUnit> MeasureUnitUpdate(
        MeasureUnitUpdateInputModel input,
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            var entity = await chain.ExecuteAsyncChain<MeasureUnitUpdateInputModel, Domain.Models.MeasureUnit>(
                EventCodes.MeasureUnitUpdate, input
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


    [GraphQLDescription("Deletes and MeasureUnit")]
    public async Task<bool> MeasureUnitDelete(
       long id,
       [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            var deleted = await chain.ExecuteAsyncChain<long, bool>(
                EventCodes.MeasureUnitDelete, id
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