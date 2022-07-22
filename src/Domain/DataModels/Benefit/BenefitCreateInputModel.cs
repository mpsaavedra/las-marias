namespace LasMarias.Domain.DataModels.Benefit;

public class BenefitCreateInputModel
{
#pragma warning disable CS8618
    public string Name { get; set; }
#pragma warning restore CS8618

    public Optional<string> Description { get; set; }

    public Optional<bool> Enable { get; set; }

    public decimal DisccountAmount { get; set; }

    [GraphQLDescription("Where the benefit is applied to, default Cost")]
    public BenefitOver Over { get; set; }
}