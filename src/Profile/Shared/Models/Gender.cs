namespace LasMarias.Profile.Domain.Models;

using System.ComponentModel.DataAnnotations;

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