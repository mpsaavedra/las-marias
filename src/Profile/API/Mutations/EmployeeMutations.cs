namespace LasMarias.Profile.Mutations;

public partial class EmployeeMutations
{
    [GraphQLDescription("creates a new employee using the provided data")]
    public async Task<Employee> EmployeeCreate(
        EmployeeCreateInputModel input,
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            var employee = await chain.ExecuteAsyncChain<EmployeeCreateInputModel, Employee>(
                EventCodes.EmployeeCreate, input
            );
            return await Task.FromResult(employee);
        }
        catch (Exception ex)
        {
            Log.Error($"Exception has occur while creating benefit: {ex.FullMessage()}");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }

    [GraphQLDescription("updates an existing employee data")]
    public async Task<Employee> EmployeeUpdate(
        EmployeeUpdateInputModel input,
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            var employee = await chain.ExecuteAsyncChain<EmployeeUpdateInputModel, Employee>(
                EventCodes.EmployeeUpdate, input
            );
            return await Task.FromResult(employee);
        }
        catch (Exception ex)
        {
            Log.Error($"Exception has occur while creating benefit: {ex.FullMessage()}");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }

    [GraphQLDescription("deletes an existing employee data")]
    public async Task<bool> EmployeeDelete(
        long id,
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            var deleted = await chain.ExecuteAsyncChain<long, bool>(
                EventCodes.EmployeeDelete, id
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