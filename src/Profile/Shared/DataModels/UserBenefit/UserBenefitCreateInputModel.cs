namespace LasMarias.Profile.Domain.DataModels.UserBenefit;

public class UserBenefitCreateInputModel
{
    [GraphQLDescription("user id")]
    public long UserId { get; set; }

    [GraphQLDescription("benefit id")]
    public long BenefitId { get; set; }
}