using System.Collections.Generic;
using Orun.Domain;
using System.Text.Json.Serialization;
using HotChocolate.Data;

namespace LasMarias.PoS.Domain.Models;

public partial class PriceFor
{
    public static PriceFor Product = new PriceFor(1, "Producto", "Precio para un producto ofertado");

    public static PriceFor Menu = new PriceFor(2, "Menu", "Precio para un menu ofertado, puede variar segun el area");

    public static PriceFor Offer = new PriceFor(3, "Oferta", "Precio de las ofertas q se ofrecen");

    public static PriceFor Service = new PriceFor(4, "Servicio", "Precio por un servicio determinado");

    public PriceFor(int code, string name)
    {
        Name = name;
        Code = code;
        Description = Name;
    }

    public PriceFor(int code, string name, string description)
    {
        Name = name;
        Code = code;
        Description = description;
    }

    public int Code { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
}