namespace LasMarias.Profile.Domain.DataModels.Employee;

[GraphQLDescription("returns a list of employees")]
public class EmployeeListPayload
{
    [GraphQLDescription("list of employees")]
    public IQueryable<Models.Employee>? Payload { get; set; }
}