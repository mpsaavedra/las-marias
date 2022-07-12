using System.ComponentModel.DataAnnotations;

namespace LasMarias.PoS.Domain.Models;

public enum SeatType
{
    [Display(Name = "Simple")]
    Single = 1,
    
    [Display(Name = "Doble")]
    Double,
    
    [Display(Name = "Triple")]
    Triple,
    
    [Display(Name = "Banca")]
    Bench,
    
    [Display(Name = "Cama de playa o piscina")]
    BeachBed,

    [Display(Name = "Silla de conferencia")]
    ConferenceChair,

    [Display(Name = "Silla de oficina")]
    OfficeChair,

    [Display(Name = "No especificado")]
    NotSpecified
}