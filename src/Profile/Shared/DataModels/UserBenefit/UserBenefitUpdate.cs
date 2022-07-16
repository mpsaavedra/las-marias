namespace LasMarias.Profile.Domain.DataModels.UserBenefit;

public class UserBenefitUpdate
{
    [GraphQLDescription("id of relation to update")]
    public long Id { get; set; }

    [GraphQLDescription("User id")]
    public long UserId { get; set; }

    [GraphQLDescription("Benefit id")]
    public long BenefitId { get; set; }
}