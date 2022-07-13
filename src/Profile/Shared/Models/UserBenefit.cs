namespace  LasMarias.Profile.Domain.Models;

[GraphQLDescription("relations between users and benefits")]
public partial class UserBenefit : BusinessEntity<long>
{   
    [GraphQLDescription("id of user benefit")]
    public long UserBenefitId { get; set; }

    [GraphQLDescription("id of user")]
    public string UserId { get; set; }

    [GraphQLDescription("id of user")]
    public long BenefitId { get; set; }

    [GraphQLDescription("Benefit")]
    [UseProjection]
    [UseSorting]
    public virtual Benefit Benefit { get; set; }

    [GraphQLDescription("User")]
    [UseProjection]
    [UseSorting]
    public virtual ApplicationUser User { get; set; }
}