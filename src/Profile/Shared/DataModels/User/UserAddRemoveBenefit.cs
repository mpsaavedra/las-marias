namespace LasMarias.Profile.Domain.DataModels.User;

public class UserAddRemoveBenefitInputModel
{
    public long Id { get; set; }

    public DataOperation Operation { get; set; }

    public long BenefitId { get; set; }
}