namespace LasMarias.PoS.Domain.Models;

using System.ComponentModel.DataAnnotations;

// THIS class is share with PoS do not change or change both to keep identical
public enum StandType
{
    [Display(Name = "Bar")]
    Bar,

    [Display(Name = "Piscina")]
    Pool,

    [Display(Name = "Lobby")]
    Lobby,

    [Display(Name = "Recepcion")]
    Reception,

    [Display(Name = "Restaurante")]
    Restaurant,

    [Display(Name = "Sala de conferencia")]    
    ConferenceRoom

}