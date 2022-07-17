namespace LasMarias.Profile.Queries;

[ExtendObjectType("Query")]
public partial class UserQueries
{
    public async Task<IQueryable<User>> GetUsers(
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            Log.Debug("User Query List: returns an Users list");
            var data = new UserListPayload();
            var fail = await chain.ExecuteAsyncChain<UserListPayload, bool>(
                EventCodes.UserList,
                data
            );
            return await Task.FromResult(data.Payload!);
        }
        catch (Exception ex)
        {
            Log.Error($"Exception while retrieving list of users: {ex.FullMessage()}");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }
}