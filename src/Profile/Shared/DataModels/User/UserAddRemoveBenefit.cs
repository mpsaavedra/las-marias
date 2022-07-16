namespace LasMarias.Profile.Domain.DataModels.User;

public class UserAddRemoveBenefit
{
    public long Id { get; set; }

    public DataOperation Operation { get; set; }

    public long BenefitId { get; set; }
}