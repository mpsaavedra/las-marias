namespace LasMarias.Profile.Domain.Models;

[GraphQLDescription("Worker's data")]
public partial class Worker : BusinessEntity<long>
{
    public Worker()
    {

    }

    [GraphQLDescription("id of worker data")]
    public long WorkerId { get; set; }

    [GraphQLDescription("id of user")]

    public string UserId { get; set; }

    [GraphQLDescription("user data")]
    [UseProjection]
    [UseSorting]
    public virtual ApplicationUser User { get; set; }

    [GraphQLDescription("type of user")]
    public UserType UserType { get; set; }

    [GraphQLDescription("status")]
    public WorkerStatus Status { get; set;}

    [GraphQLIgnore]
    public DateTime? HiredDate { get; set; }

    [GraphQLIgnore]
    public DateTime? FiredDate { get; set; }

}