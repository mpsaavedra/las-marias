namespace LasMarias.Profile.Domain.Models;

using System.ComponentModel.DataAnnotations;

public enum ReleaseReason
{
    [Display(Name = "Despido")]
    Fired = 1,

    [Display(Name = "Solicitada")]
    Requested,

    [Display(Name = "Retiro por edad")]
    Retirement,

    [Display(Name = "Otra razón")]
    Other,

    [Display(Name = "No especificada")]
    NotSpecified
}