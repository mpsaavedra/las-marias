namespace LasMarias.Queries;

[ExtendObjectType("Query")]
public partial class TableQueries
{
    [GraphQLDescription("List all available Table")]
    public async Task<IQueryable<Table>> GetTables(
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("Table Query List: returns a Table List");
            var data = new TableListPayload();
            var fail = await chain.ExecuteAsyncChain<TableListPayload, bool>(
                EventCodes.TableList,
                data
            );
            return await Task.FromResult(data.Payload!);
        }
        catch (System.Exception ex)
        {
            Log.Error($"Exception while retrieving list of Table: {ex.FullMessage()} ");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }

    }
}