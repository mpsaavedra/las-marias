namespace LasMarias.Domain.DataModels.UserBenefit;

public class UserBenefitUpdateInputModel
{

    public long Id { get; set; }

    public Optional<string> UserId { get; set; }

    public Optional<long> BenefitId { get; set; }
}