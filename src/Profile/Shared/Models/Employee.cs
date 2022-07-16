namespace LasMarias.Profile.Domain.Models;

[GraphQLDescription("Employee's data")]
public partial class Employee : BusinessEntity<long>
{
    public Employee()
    {
        ReleaseReason = Models.ReleaseReason.NotSpecified;
        EmployeeType = EmployeeType.Employee; // employee as default
    }

    public Employee(User user, EmployeeType employeeType, DateOnly dateOfBirth, EmployeeStatus status,
                   DateOnly hiredDate)
    {
        User = user;
        EmployeeType = employeeType;
        DateOfBirth = dateOfBirth;
        Status = status;
        HiredDate = hiredDate;
    }

    [GraphQLDescription("id of Employee data")]
    public long EmployeeId { get; set; }

    [GraphQLDescription("id of user")]

    public long UserId { get; set; }

    [GraphQLDescription("user data")]
    [UseProjection]
    [UseSorting]
    public virtual User? User { get; set; }

    [GraphQLDescription("type of user")]
    public EmployeeType EmployeeType { get; set; }

    [GraphQLDescription("Date of birth")]
    public DateOnly? DateOfBirth { get; set; }

    [GraphQLDescription("status")]
    public EmployeeStatus Status { get; set; }

    [GraphQLDescription("date in chich was hired")]
    public DateOnly? HiredDate { get; set; }

    [GraphQLDescription("date in which was release")]
    public DateOnly? ReleaseDate { get; set; }

    [GraphQLDescription("release reason")]
    public ReleaseReason? ReleaseReason { get; set; }

    [GraphQLDescription("Note to describe te release reason")]
    public string? ReleaseNote { get; set; }

}