namespace LasMarias.Profile.Domain.DataModels.Employee;

public class EmployeeCreateInputModel
{
    public long UserId { get; set; }

    public Optional<EmployeeType> EmployeeType { get; set; }

    public Optional<DateOnly> DateOfBirth { get; set; }

    public Optional<EmployeeStatus> Status { get; set; }

    public Optional<DateOnly> HiredDate { get; set; }
}