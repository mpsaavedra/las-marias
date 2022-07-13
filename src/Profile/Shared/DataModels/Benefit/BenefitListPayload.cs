namespace LasMarias.Profile.Domain.DataModels.Benefit;

using LasMarias.Profile.Domain.Models;

public class BenefitListPayload
{
    public ICollection<Benefit>? Payload { get; set; }
}