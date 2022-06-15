namespace LasMarias.Hub.Domain.InputModels.UserBenefit;

public partial class UserBenefitCreateInputModel
{
    public long ApplicationUserId { get; set; }
    
    public long BenefitId { get; set; }
}