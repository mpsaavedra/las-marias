namespace LasMarias.Profile.Domain.Models;

[GraphQLDescription("Employee's data")]
public partial class Employee : BusinessEntity<long>
{
    public Employee()
    {
        ReleaseReason = Models.ReleaseReason.NotSpecified;
        UserType = UserType.Employee; // employee as default
    }

    [GraphQLDescription("id of Employee data")]
    public long EmployeeId { get; set; }

    [GraphQLDescription("id of user")]

    public string UserId { get; set; }

    [GraphQLDescription("user data")]
    [UseProjection]
    [UseSorting]
    public virtual ApplicationUser User { get; set; }

    [GraphQLDescription("type of user")]
    public UserType UserType { get; set; }

    [GraphQLDescription("Date of birth")]
    public DateOnly? DateOfBirth { get; set; }

    [GraphQLDescription("status")]
    public EmployeeStatus Status { get; set;}

    [GraphQLDescription("date in chich was hired")]
    public DateTime? HiredDate { get; set; }

    [GraphQLDescription("date in which was release")]
    public DateTime? ReleaseDate { get; set; }

    [GraphQLDescription("release reason")]
    public ReleaseReason? ReleaseReason { get; set; }

    [GraphQLDescription("Note to describe te release reason")]
    public string? ReleaseNote { get; set; }

}