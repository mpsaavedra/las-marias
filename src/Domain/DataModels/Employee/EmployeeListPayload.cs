namespace LasMarias.Domain.DataModels.Employee;

public class EmployeeListPayload
{
    public IQueryable<Domain.Models.Employee>? Payload { get; set; }
}