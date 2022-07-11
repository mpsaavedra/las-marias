namespace LasMarias.PoS.Domain.Models;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// define the possible statuses orders pass
/// </summary>
public enum OrderStatus
{
    /// <summary>
    /// order requested , mostly used to make request to the kitchen or bar using
    // the sytems internal mechanism
    /// </summary>
    [Display(Name = "Solicitada")]
    Request = 1,
    
    /// <summary>
    /// order to be prepared
    /// </summary>
    [Display(Name = "Ordenada")]
    Ordered,
    
    /// <summary>
    /// this field is used to describe an order that has been 
    /// received by a stand holder or the kitchen responsible
    /// </summary>
    [Display(Name = "Recibida")]
    Received,
    
    /// <summary>
    /// it is been prepared in kitchen or bar
    /// </summary>
    [Display(Name = "En Preparacion")]
    Prepared,
    
    /// <summary>
    /// ready to be deliver to the client
    /// </summary>
    [Display(Name = "Lista")]
    Ready,
    
    /// <summary>
    /// delivered to the client
    /// </summary>
    [Display(Name = "Entregada")]
    Delivered,
    
    /// <summary>
    /// payed by client
    /// </summary>
    [Display(Name = "Pagada")]
    Paid,
    
    /// <summary>
    /// cancel for some reason that shoul be secified
    /// in the cancel reason of the order
    /// </summary>
    [Display(Name = "Cancelada")]
    Cancelled
}