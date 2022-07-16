namespace LasMarias.Profile.Domain.Models;

[GraphQLDescription("Over which value apply the benefit deduction")]
public enum BenefitOver
{
    [Display(Name = "Sobre precio de costo")]
    Cost = 1,

    [Display(Name = "Sobre precio de venta")]
    SellingPrice
}