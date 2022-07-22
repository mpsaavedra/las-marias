namespace LasMarias.Domain.Models;

[GraphQLDescription("relations between users and benefits")]
public partial class UserBenefit : BusinessEntity<long>
{
    public UserBenefit()
    {
    }

    public UserBenefit(ApplicationUser user, Benefit benefit)
    {
        User = user;
        Benefit = benefit;
    }

    [GraphQLDescription("id of user benefit")]
    public long UserBenefitId { get; set; }

    [GraphQLDescription("id of user")]
    public string? UserId { get; set; }

    [GraphQLDescription("id of user")]
    public long? BenefitId { get; set; }

    [GraphQLDescription("Benefit")]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public virtual Benefit? Benefit { get; set; }

    [GraphQLDescription("User")]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public virtual ApplicationUser? User { get; set; }
}