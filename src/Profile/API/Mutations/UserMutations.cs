namespace LasMarias.Profile.Mutations;

public partial class UserMutations
{
    [GraphQLDescription("creates a new user")]
    public async Task<User> UserCreate(
        UserCreateInputModel input,
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            var user = await chain.ExecuteAsyncChain<UserCreateInputModel, User>(
                EventCodes.UserCreate,
                input
            );
            return await Task.FromResult(user);
        }
        catch (Exception ex)
        {
            Log.Error($"Exception has occur while creating benefit: {ex.FullMessage()}");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }

    [GraphQLDescription("updates user information")]
    public async Task<User> UserUpdate(
        UserUpdateInputModel input,
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            var user = await chain.ExecuteAsyncChain<UserUpdateInputModel, User>(
                EventCodes.UserUpdate,
                input
            );
            return await Task.FromResult(user);
        }
        catch (Exception ex)
        {
            Log.Error($"Exception has occur while creating benefit: {ex.FullMessage()}");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }

    [GraphQLDescription("delete an existin user")]
    public async Task<bool> UserDelete(
        long id,
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            var deleted = await chain.ExecuteAsyncChain<long, bool>(
                EventCodes.UserDelete,
                id
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

    [GraphQLDescription("add/remove an user benefit from user")]
    public async Task<User> UserAddRemoveBenefit(
        UserAddRemoveBenefitInputModel input,
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            var user = await chain.ExecuteAsyncChain<UserAddRemoveBenefitInputModel, User>(
                EventCodes.UserAddRemoveBenefit,
                input
            );
            return await Task.FromResult(user);
        }
        catch (Exception ex)
        {
            Log.Error($"Exception has occur while creating benefit: {ex.FullMessage()}");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }
}