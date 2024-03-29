namespace LasMarias.Domain.Models;

using System.ComponentModel.DataAnnotations;

public enum MovementType
{
    [Display(Name = "Entrada")]
    Reception,

    [Display(Name = "Salida")]
    Deliver,

    [Display(Name = "Salida a Area")]
    DeliverToStand,

    [Display(Name = "Fecha de caducidad")]
    Expiration,

    [Display(Name = "Not defined")]
    NotDefined
}