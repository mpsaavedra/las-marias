namespace LasMarias.Profile.Domain.DataModels.Benefit;

[GraphQLDescription("basic data to create a new Benefit")]
public class BenefitCreateInputModel
{
    [GraphQLDescription("Name of benefit")]
    public string Name { get; set; }

    [GraphQLDescription("descriptioin of how, when and why to apply this benefit")]
    public Optional<string> Description { get; set; }

    [GraphQLDescription("if is enable to be used in the system")]
    public Optional<bool> Enable { get; set; }

    [GraphQLDescription("Discount applied by concept of use this benefit")]
    public Optional<decimal> DiscountAmount { get; set; }
}