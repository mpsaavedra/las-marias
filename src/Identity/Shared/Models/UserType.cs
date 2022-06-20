using System.ComponentModel.DataAnnotations;

namespace LasMarias.Identity.Shared.Models;

/// <summary>
/// defines the different types an user could be
/// </summary>
public enum UserType
{
    [Display(Name = "Dueño")]
    Owner,
    
    [Display(Name = "Administrador")]
    Administrator,
    
    [Display(Name = "Manager")]
    Manager,
    
    [Display(Name = "Trabajador")]
    Worker,
    
    [Display(Name = "Cliente")]
    Client,
    
    [Display(Name = "Proveedor")]
    Provider
}