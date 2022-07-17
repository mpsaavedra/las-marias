namespace LasMarias.Profile.Queries;

[ExtendObjectType("Query")]
public partial class EmployeeQueries
{
    public async Task<IQueryable<Employee>> GetEmployees(
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            Log.Debug("Employee Query List: returns a list with all available employees");
            var data = new EmployeeListPayload();
            var fail = await chain.ExecuteAsyncChain<EmployeeListPayload, bool>(
                EventCodes.EmployeeList, data
            );
            return await Task.FromResult(data.Payload!);
        }
        catch (System.Exception ex)
        {
            Log.Error($"Exception while retrieving list of Employees {ex.FullMessage()}");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }
}