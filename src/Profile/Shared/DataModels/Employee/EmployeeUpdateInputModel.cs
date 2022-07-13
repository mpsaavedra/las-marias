namespace LasMarias.Profile.Domain.DataModels.Employee;

public class EmployeeUpdateInputModel
{
    [GraphQLDescription("id of employee")]
    public long Id { get; set; }

    [GraphQLDescription("id os user ")]
    public Optional<string> UserId { get; set; }

    [GraphQLDescription("user type")]
    public Optional<UserType> UserType { get; set; }

    [GraphQLDescription("Date of birth")]
    public Optional<DateOnly> DateOfBirth { get; set; }

    [GraphQLDescription("employee status")]
    public Optional<EmployeeStatus> Status { get; set; }

    [GraphQLDescription("date in which was hired")]
    public Optional<DateTime> HiredDate { get; set; }

    [GraphQLDescription("date in which was fired or leave the job")]
    public Optional<DateTime> ReleaseDate { get; set; }

    [GraphQLDescription("Note to describe the release reason")]
    public Optional<ReleaseReason> ReleaseReson { get; set; }
}