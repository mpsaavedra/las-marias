namespace LasMarias.Profile.Domain.Models;

[GraphQLDescription("relations between users and benefits")]
public partial class UserBenefit : BusinessEntity<long>
{
    public UserBenefit()
    {
    }

    public UserBenefit(User user, Benefit benefit)
    {
        User = user;
        Benefit = benefit;
    }

    [GraphQLDescription("id of user benefit")]
    public long UserBenefitId { get; set; }

    [GraphQLDescription("id of user")]
    public long? UserId { get; set; }

    [GraphQLDescription("id of user")]
    public long? BenefitId { get; set; }

    [GraphQLDescription("Benefit")]
    [UseProjection]
    [UseSorting]
    public virtual Benefit? Benefit { get; set; }

    [GraphQLDescription("User")]
    [UseProjection]
    [UseSorting]
    public virtual User? User { get; set; }
}