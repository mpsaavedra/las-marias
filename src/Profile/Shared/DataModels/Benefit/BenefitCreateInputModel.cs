namespace LasMarias.Profile.Domain.DataModels.Benefit;

[GraphQLDescription("Required data to create a new User benefit")]
public class BenefitCreateInputModel
{
    [GraphQLDescription("name of benefit")]
    public string? Name { get; set; }

    [GraphQLDescription("discounted mount when using this benefit")]
    public decimal DiscountAmount { get; set; }

    [GraphQLDescription("Desciption of the benefit, when and how to use it")]
    public Optional<string> Description { get; set; }

    public Optional<bool> Enable { get; set; }
}