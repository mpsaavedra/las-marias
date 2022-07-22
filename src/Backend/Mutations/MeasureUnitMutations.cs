namespace LasMarias.Mutations;

[ExtendObjectType("Mutation")]
public class MeasureUnitMutations
{
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