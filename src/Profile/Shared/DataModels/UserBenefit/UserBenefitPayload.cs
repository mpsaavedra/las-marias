namespace LasMarias.Profile.Domain.DataModels.UserBenefit;

using LasMarias.Profile.Domain.Models;

public class UserBenefitPayload
{
    public ICollection<UserBenefit>? Payload { get; set; }
}