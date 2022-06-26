namespace LasMarias.WareHouse.Domain.Models;

using System.ComponentModel.DataAnnotations;

// THIS class is share with PoS do not change or change both to keep identical
public class StandType
{
    public static StandType Bar = new StandType(1, "Bar");

    public static StandType Pool = new StandType(2, "Piscina");

    public static StandType Lobby = new StandType(3, "Lobby");

    public static StandType Reception = new StandType(4, "Recepcion");

    public static StandType Restaurant = new StandType(5, "Restaurante");
    
    public static StandType ConferenceRoom = new StandType(6, "Sala de conferencia");

    public StandType(int code, string name)
    {
        Code = code;
        Name = name;
        Description = Name;
    }

    public StandType(int code, string name, string description)
    {
        Code = code;
        Name = name;
        Description = description;
    }

    public int Code { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
}