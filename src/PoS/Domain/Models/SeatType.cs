using System.ComponentModel.DataAnnotations;

namespace LasMarias.PoS.Domain.Models;

public class SeatType
{
    public static SeatType Single = new SeatType(1, "Simple", "Espacio para una sola persona");
    
    public static SeatType Double = new SeatType(2, "Doble", "Espacio para dos personas");
    
    public static SeatType Triple = new SeatType(3, "Triple", "Espacio para tres personas");
    
    
    public static SeatType Bench = new SeatType(4, "Banca", "Banca para varias personas");
    
    public static SeatType BeachBed = new SeatType(5, "Cama de playa o piscina", "Cama playera o de piscina");

    public SeatType(int code, string name)
    {
        Code = code;
        Name = name;
        Description = name;
    }

    public SeatType(int code, string name, string description)
    {
        Code = code;
        Name = name;
        Description = description;
    }

    public int Code { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
}