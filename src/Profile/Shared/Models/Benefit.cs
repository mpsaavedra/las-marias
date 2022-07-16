namespace LasMarias.Profile.Domain.Models;

[GraphQLDescription("Benefits of clients")]
public partial class Benefit : BusinessEntity<long>
{
    public Benefit()
    {
        Enable = true;
        DiscountAmount = 0m;
        Name = "";
        UserBenefits = new HashSet<UserBenefit>();
    }

    public Benefit(string name, decimal discountAmount)
    {
        Name = name;
        DiscountAmount = discountAmount;
        Enable = true;
        UserBenefits = new HashSet<UserBenefit>();
    }

    [GraphQLDescription("id of benefit")]
    public long BenefitId { get; set; }

    [GraphQLDescription("Name (descriptive)")]
    public string Name { get; set; }

    [GraphQLDescription("Benefit description about the benefit, it could include instructions about how to apply it")]
    public string? Description { get; set; }

    [GraphQLDescription("If true is available to be applied in orders")]
    public bool Enable { get; set; }

    [GraphQLDescription("Discount amout that will be applied to the final bill")]
    public decimal DiscountAmount { get; set; }

    [GraphQLDescription("list of user with this benefit")]
    [UseProjection]
    [UseSorting]
    public virtual ICollection<UserBenefit> UserBenefits { get; set; }
}