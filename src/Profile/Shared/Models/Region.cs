namespace LasMarias.Profile.Domain.Models;

/// <summary>
/// general geographical regions
/// </summary>
[GraphQLDescription("Country region")]
public enum Region
{
    [Display(Name = "Sin especificar")]
    NotSpecified,

    [Display(Name = "Norte America")]
    NorthAmerica,

    [Display(Name = "Centro America")]
    CentralAmerica,

    [Display(Name = "Suramerica")]
    SouthAmerica,

    [Display(Name = "Caribe")]
    Caribbean,

    [Display(Name = "Europa")]
    Europe,

    [Display(Name = "Europa del Este")]
    WestEurope,

    [Display(Name = "Africa")]
    Africa,

    [Display(Name = "Asia")]
    Asia
}