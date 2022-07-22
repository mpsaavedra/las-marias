namespace LasMarias.Domain.DataModels.Employee;

public class EmployeeCreateInputModel
{
#pragma warning disable CS8618
    public string UserId { get; set; }
#pragma warning restore CS8618

    [GraphQLDescription("default Employee")]
    public Optional<Domain.Models.EmployeeType> EmployeeType { get; set; }

    public Optional<DateOnly> DateOfBirth { get; set; }

    public Optional<EmployeeStatus> Status { get; set; }

    public Optional<DateOnly> HiredDate { get; set; }
}