namespace LasMarias.Queries;

[ExtendObjectType("Query")]
public partial class AttributeNameQueries
{
    [GraphQLDescription("List all available AttributeName")]
    public async Task<IQueryable<AttributeName>> GetAttributeNames(
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("AttributeName Query List: returns a AttributeName List");
            var data = new AttributeNameListPayload();
            var fail = await chain.ExecuteAsyncChain<AttributeNameListPayload, bool>(
                EventCodes.AttributeNameList,
                data
            );
            return await Task.FromResult(data.Payload!);
        }
        catch (System.Exception ex)
        {
            Log.Error($"Exception while retrieving list of AttributeName: {ex.FullMessage()} ");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }

    }
}
