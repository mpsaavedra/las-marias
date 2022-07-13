namespace LasMarias.Profile.Domain.Models;

using System.ComponentModel.DataAnnotations;

[GraphQLDescription("Different workers clasifications")]
public enum UserType
{
    [Display(Name = "Empleado(a)")]
    Employee = 1,

    [Display(Name = "Dueño(a)")]
    Owner,
    
    [Display(Name = "Administrador(a)")]
    Administrator,
    
    [Display(Name = "Manager")]
    Manager,
    
    [Display(Name = "Mesero(a)")]
    Waitress,
    
    [Display(Name = "Proveedor(a)")]
    Provider
}