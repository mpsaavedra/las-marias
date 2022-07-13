namespace LasMarias.Profile.Domain.Models;

using System.ComponentModel.DataAnnotations;


/// <summary>
/// define the current status of a Employee, this could be used
/// for Employees checkin or checkout
/// </summary>
public enum EmployeeStatus
{ 
    [Display(Name = "No trabajando")]
    NotWorking,

    [Display(Name = "Trabajando")] 
    Working,
    
    [Display(Name = "Despedido")]
    Fired
}