namespace LasMarias.WareHouse.Domain.Models;

[GraphQLDescription("Different stands avalaible to this system")]
public enum StandType
{
    [Display(Name = "Bar")]
    Bar = 1,

    [Display(Name = "Piscina")]
    Pool,
    
    [Display(Name = "Lobby")]
    Lobby,
    
    [Display(Name = "Recepcion")]
    Reception,
    
    [Display(Name = "Restaurante")]
    Restaurant,
    
    [Display(Name = "Sala de conferencias")]
    ConferenceRoom,

    [Display(Name = "Almacen")]
    WareHouse,

    [Display(Name = "Cocina")]
    Kitchen,

    [Display(Name = "Sin especificar")]
    NotSpecified
}