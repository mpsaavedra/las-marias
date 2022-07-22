namespace LasMarias.Mutations;

[ExtendObjectType("Mutation")]
public class UserBenefitMutations
{
    public async Task<Domain.Models.UserBenefit> UserBenefitCreate(
        UserBenefitCreateInputModel input,
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            var entity = await chain.ExecuteAsyncChain<UserBenefitCreateInputModel, Domain.Models.UserBenefit>(
                EventCodes.UserBenefitCreate, input
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

    public async Task<Domain.Models.UserBenefit> UserBenefitUpdate(
        UserBenefitUpdateInputModel input,
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            var entity = await chain.ExecuteAsyncChain<UserBenefitUpdateInputModel, Domain.Models.UserBenefit>(
                EventCodes.UserBenefitUpdate, input
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


    [GraphQLDescription("Deletes and UserBenefit")]
    public async Task<bool> UserBenefitDelete(
       long id,
       [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            var deleted = await chain.ExecuteAsyncChain<long, bool>(
                EventCodes.UserBenefitDelete, id
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