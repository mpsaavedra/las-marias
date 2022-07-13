namespace LasMarias.Profile.Domain.DataModels.Benefit;

public class BenefitUpdateInputModel
{
    public long Id { get; set; }

    public Optional<string> Name { get; set; }

    public Optional<string> Description { get; set; }

    public Optional<bool> Enable { get; set; }

    public Optional<decimal> DiscountAmount { get; set; }
}