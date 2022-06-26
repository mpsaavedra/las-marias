namespace LasMarias.PoS.Domain.Models;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// define the possible statuses orders pass
/// </summary>
public class OrderStatus
{
    /// <summary>
    /// order requested , mostly used to make request to the kitchen or bar using
    // the sytems internal mechanism
    /// </summary>
    public static OrderStatus Request = new OrderStatus(1, "Solicitada", "Orden solicitada usando internet o mecanismos internos del sistema");
    
    /// <summary>
    /// order to be prepared
    /// </summary>
    public static OrderStatus Ordered = new OrderStatus(1, "Ordenada", "La orden ha sido enviada por el mesero-bartender a otra area para su preparacion");
    
    /// <summary>
    /// this field is used to describe an order that has been 
    /// received by a stand holder or the kitchen responsible
    /// </summary>
    public static OrderStatus Received = new OrderStatus(1, "Recibida", "La orden ha sido recibida en el area de preparacion");
    
    /// <summary>
    /// it is been prepared in kitchen or bar
    /// </summary>
    public static OrderStatus Prepared = new OrderStatus(1, "Elaborandose", "La orden se encuentra en el area de preparacion y esta siendo preparada");
    
    /// <summary>
    /// ready to be deliver to the client
    /// </summary>
    public static OrderStatus Ready = new OrderStatus(1, "Lista", "La orden ya esta lista para ser entregada");
    
    /// <summary>
    /// delivered to the client
    /// </summary>
    public static OrderStatus Delivered = new OrderStatus(1, "Entregada", "La orden ha sido entregada al cliente");
    
    /// <summary>
    /// payed by client
    /// </summary>
    public static OrderStatus Paid = new OrderStatus(1, "Pagada", "La orden ha sido pagada por el");
    
    /// <summary>
    /// cancel for some reason that shoul be secified
    /// in the cancel reason of the order
    /// </summary>
    public static OrderStatus Cancelled = new OrderStatus(1, "Cancelada", "La Orden ha sido cancelada, en este caso especificar la razon");

    public OrderStatus(int code, string name)
    {
        Code = code;
        Name = name;
        Description = name;
    }

    public OrderStatus(int code, string name, string description)
    {
        Code = code;
        Name = name;
        Description = description;
    }

    public int Code { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
}