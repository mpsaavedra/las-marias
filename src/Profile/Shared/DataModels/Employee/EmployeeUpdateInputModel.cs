namespace LasMarias.Profile.Domain.DataModels.Employee;

public class EmployeeUpdateInputModel
{
    public long Id { get; set; }

    public Optional<long> UserId { get; set; }

    public Optional<EmployeeType> EmployeeType { get; set; }

    public Optional<DateOnly> DateOfBirth { get; set; }

    public Optional<EmployeeStatus> Status { get; set; }

    public Optional<DateOnly> HiredDate { get; set; }

    public Optional<DateOnly> ReleaseDate { get; set; }

    public Optional<ReleaseReason> ReleaseReason { get; set; }

    public Optional<string> ReleaseNote { get; set; }
}