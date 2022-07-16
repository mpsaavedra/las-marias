namespace LasMarias.Profile.Domain.DataModels.Benefit;

[GraphQLDescription("data to update a benefit")]
public class BenefitUpdateInputModel
{
    [GraphQLDescription("id of benefit to update")]
    public long Id { get; set; }

    [GraphQLDescription("name")]
    public Optional<string> Name { get; set; }

    [GraphQLDescription("description about benefit, how and when to use it")]
    public Optional<string> Description { get; set; }

    [GraphQLDescription("if is active in the system")]
    public Optional<bool> Enable { get; set; }

    [GraphQLDescription("Over with price apply benefit discount")]
    public Optional<BenefitOver> Over { get; set; }

    [GraphQLDeprecated("discount amount when using the benefit")]
    public Optional<decimal> DiscountAmount { get; set; }
}