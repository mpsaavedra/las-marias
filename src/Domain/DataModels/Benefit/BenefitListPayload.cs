namespace LasMarias.Domain.DataModels.Benefit;

public class BenefitListPayload
{
    public IQueryable<Domain.Models.Benefit>? Payload { get; set; }
}