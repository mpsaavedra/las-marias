namespace LasMarias.Queries;

[ExtendObjectType("Query")]
public partial class ApplicationUserQueries
{
    [GraphQLDescription("List all available ApplicationUser")]
    public async Task<IQueryable<ApplicationUser>> GetApplicationUsers(
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("ApplicationUser Query List: returns a ApplicationUser List");
            var data = new ApplicationUserListPayload();
            var fail = await chain.ExecuteAsyncChain<ApplicationUserListPayload, bool>(
                EventCodes.ApplicationUserList,
                data
            );
            return await Task.FromResult(data.Payload!);
        }
        catch (System.Exception ex)
        {
            Log.Error($"Exception while retrieving list of ApplicationUser: {ex.FullMessage()} ");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }

    }
}