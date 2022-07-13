namespace LasMarias.Profile.Domain.DataModels.Employee;

using LasMarias.Profile.Domain.Models;

public class EmployeeListPayload
{
    [GraphQLDescription("list of employees")]
    public ICollection<Employee>? Payload { get; set; }
}