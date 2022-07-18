namespace LasMarias.Profile.Mutations;

[ExtendObjectType("Mutation")]
public class BenefitMutations
{
    [GraphQLDescription("Creates a new user benfit")]
    public async Task<Benefit> BenefitCreate(
        BenefitCreateInputModel input,
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            var benefit = await chain.ExecuteAsyncChain<BenefitCreateInputModel, Benefit>(
                EventCodes.BenefitCreate, input
            );
            return await Task.FromResult(benefit);
        }
        catch (Exception ex)
        {
            Log.Error($"Exception has occur while creating benefit: {ex.FullMessage()}");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }

    [GraphQLDescription("Updates benefit with provided information")]
    public async Task<Benefit> BenefitUpdate(
        BenefitUpdateInputModel input,
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            var benefit = await chain.ExecuteAsyncChain<BenefitUpdateInputModel, Benefit>(
                EventCodes.BenefitUpdate,
                input
            );
            return await Task.FromResult(benefit);
        }
        catch (Exception ex)
        {
            Log.Error($"Exception has occur while creating benefit: {ex.FullMessage()}");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }

    [GraphQLDescription("Deletes an existing Benefit")]
    public async Task<bool> BenefitDelete(
        long id,
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            var deleted = await chain.ExecuteAsyncChain<long, bool>(
                EventCodes.BenefitDelete, id
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