using System.Collections.Generic;
using Orun.Domain;
using System.Text.Json.Serialization;
using HotChocolate.Data;

namespace LasMarias.WareHouse.Domain.Models;

public class MovementType
{
    public static MovementType Reception = new MovementType(1, "Recepcion", "Uno o varios productos son recibidos y se le da entrada al almacen");

    public static MovementType Deliver = new MovementType(2, "Salida", "Un o varios productos se sacan del almacen");

    public static MovementType DeliverToStand = new MovementType(3, "Salida a area", "Uno o varios productos se envian a un area especifica");

    public static MovementType Expiration = new MovementType(4, "Baja por Expiracion", "Un o varios productos se desechan por fecha de caducacion");


    public MovementType(int code, string name)
    {
        Code = code;
        Name = name;
        Description = name;
    }

    public MovementType(int code, string name, string description)
    {
        Code = code;
        Name = name;
        Description = description;
    }

    public int Code { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }
}