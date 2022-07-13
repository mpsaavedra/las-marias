namespace LasMarias.Profile.Domain.DataModels.Employee;

[GraphQLDescription("Basic information to delete an employee")]
public class EmployeeDeleteInputModel
{
    [GraphQLDescription("id of employee")]
    public long Id { get; set; }
}