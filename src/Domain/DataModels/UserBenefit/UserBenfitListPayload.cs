namespace LasMarias.Domain.DataModels.UserBenefit;

public class UserBenefitListPayload
{
    public IQueryable<Domain.Models.UserBenefit>? Payload { get; set; }
}