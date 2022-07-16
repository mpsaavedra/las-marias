namespace LasMarias.Profile.Domain.DataModels.UserBenefit;

[GraphQLDescription("returns a list of user benefits relations")]
public class UserBenefitListPayload
{
    [GraphQLDescription("List of user benefits")]
    public IQueryable<Models.UserBenefit>? Payload { get; set; }
}