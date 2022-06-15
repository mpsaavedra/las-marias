using System.ComponentModel.DataAnnotations;

namespace LasMarias.Hub.Domain.Models;

public enum Gender
{
    [Display(Name = "Masculino")]
    Male = 1,
    
    [Display(Name = "Femenino")]
    Female,
    
    [Display(Name = "No especificado")]
    NotDefined
}