namespace LasMarias.Domain.Models;

[GraphQLDescription("Genero de usuario")]
public enum Gender
{
    [Display(Name = "Masculino")]
    Male = 1,

    [Display(Name = "Femenino")]
    Female,

    [Display(Name = "No especificado")]
    NotSpecified
}