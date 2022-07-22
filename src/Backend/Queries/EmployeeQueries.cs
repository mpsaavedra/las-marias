namespace LasMarias.Queries;

[ExtendObjectType("Query")]
public partial class EmployeeQueries
{
    [GraphQLDescription("List all available Employee")]
    public async Task<IQueryable<Employee>> GetEmployees(
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("Employee Query List: returns a Employee List");
            var data = new EmployeeListPayload();
            var fail = await chain.ExecuteAsyncChain<EmployeeListPayload, bool>(
                EventCodes.EmployeeList,
                data
            );
            return await Task.FromResult(data.Payload!);
        }
        catch (System.Exception ex)
        {
            Log.Error($"Exception while retrieving list of Employee: {ex.FullMessage()} ");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }

    }
}