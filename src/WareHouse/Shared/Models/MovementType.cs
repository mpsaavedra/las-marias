using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Orun.Domain;
using System.Text.Json.Serialization;
using HotChocolate.Data;

namespace LasMarias.WareHouse.Domain.Models;

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