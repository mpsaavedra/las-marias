namespace LasMarias.Queries;

[ExtendObjectType("Query")]
public partial class AttributeQueries
{
    [GraphQLDescription("List all available Attribute")]
    public async Task<IQueryable<Domain.Models.Attribute>> GetAttributes(
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("Attribute Query List: returns a Attribute List");
            var data = new AttributeListPayload();
            var fail = await chain.ExecuteAsyncChain<AttributeListPayload, bool>(
                EventCodes.AttributeList,
                data
            );
            return await Task.FromResult(data.Payload!);
        }
        catch (System.Exception ex)
        {
            Log.Error($"Exception while retrieving list of Attribute: {ex.FullMessage()} ");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }

    }
}
