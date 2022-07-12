using System.Collections.Generic;
using Orun.Domain;
using System.Text.Json.Serialization;
using HotChocolate.Data;

namespace LasMarias.PoS.Domain.Models;

[GraphQLDescription("describes a seat")]
public partial class Seat : BusinessEntity<long>
{
    private int _capacity;

    public Seat()
    {
        SeatType = SeatType.NotSpecified;
        _capacity = 0;
    }

    [GraphQLDescription("id of seat")]
    public long SeatId { get; set; }

    [GraphQLDescription("code to identify the seat on the table")]
    public string? Code { get; set; }

    [GraphQLDescription("id of the table, it could be null if it is at the bar or an open stand/area")]
    public long? TableId { get; set; }

    [GraphQLDescription("table this seat is set, it could be null if it is at the bar or an open stand/area")]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual Table? Table { get; set; }

    [GraphQLDescription("id of stand")]
    public long StandId { get; set; }

    [GraphQLDescription("stand this seat is located")]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual Stand Stand { get; set; }

    [GraphQLDescription("inventary number")]
    public string? InventaryNumber { get; set; }
    
    [GraphQLDescription("seat type")]
    public SeatType SeatType { get; set; }

    [GraphQLDescription("number of seats taken if there is more than one")]
    public int Occupied { get; set; }

    [GraphQLDescription("Capacity of the seat")]
    public int Capacity => _capacity;

    [GraphQLDescription("Available positions for this seat, it depends on the SeatType, allows to set different capacities when is a banch or else")]
    public int Positions 
    { 
        get => _capacity;
        set 
        {
            switch (SeatType)
            {
                case SeatType.Single:
                    _capacity = 1;
                    break;
                case SeatType.Double:
                    _capacity = 2;
                    break;
                case SeatType.Triple:
                    _capacity = 3;
                    break;
                default:
                    _capacity = 0;
                    break;
            }
        }
    }
}