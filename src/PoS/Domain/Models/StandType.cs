namespace LasMarias.PoS.Domain.Models;

using System.ComponentModel.DataAnnotations;

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
    ConferenceRoom
}