namespace LasMarias.Domain.DataModels.Benefit;

public class BenefitUpdateInputModel
{
    public long Id { get; set; }

#pragma warning disable CS8618
    public Optional<string> Name { get; set; }
#pragma warning restore CS8618

    public Optional<string> Description { get; set; }

    public Optional<bool> Enable { get; set; }

    public Optional<decimal> DisccountAmount { get; set; }

    [GraphQLDescription("Where the benefit is applied to, default Cost")]
    public Optional<BenefitOver> Over { get; set; }
}