using System.ComponentModel.DataAnnotations;

namespace LasMarias.Hub.Domain.Models;

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