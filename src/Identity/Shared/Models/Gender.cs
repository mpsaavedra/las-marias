using System.ComponentModel.DataAnnotations;

namespace LasMarias.Identity.Shared.Models;

/// <summary>
/// different user genders
/// </summary>
public enum Gender
{
    [Display(Name = "Masculino")]
    Male = 1,
    
    [Display(Name = "Femenino")]
    Female,
    
    [Display(Name = "No especificado")]
    NotDefined
}