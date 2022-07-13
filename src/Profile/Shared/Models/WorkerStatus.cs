namespace LasMarias.Profile.Domain.Models;

using System.ComponentModel.DataAnnotations;


/// <summary>
/// define the current status of a worker, this could be used
/// for workers checkin or checkout
/// </summary>
public enum WorkerStatus
{ 
    [Display(Name = "No trabajando")]
    NotWorking,

    [Display(Name = "Trabajando")] 
    Working,
    
    [Display(Name = "Despedido")]
    Fired
}