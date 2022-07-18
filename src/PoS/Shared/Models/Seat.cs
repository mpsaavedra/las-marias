using System.Collections.Generic;
using Orun.Domain;
using System.Text.Json.Serialization;
using HotChocolate.Data;

namespace LasMarias.PoS.Domain.Models;

[GraphQLDescription("describes a seat")]
public partial class Seat : BusinessEntity<long>
{
    private int _capacity;
    private int _ocuppied;

    public Seat()
    {
        SeatType = SeatType.NotSpecified;
        _capacity = 0;
        _ocuppied = 0;
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
    public virtual Stand Stand { get; set; }

    [GraphQLDescription("inventary number")]
    public string? InventaryNumber { get; set; }

    [GraphQLDescription("seat type")]
    public SeatType SeatType { get; set; }

    [GraphQLDescription("number of seats taken if there is more than one")]
    public int Occupied
    {
        get => _ocuppied;
        set
        {
            if (value > Capacity)
            {
                throw new Exception("The specified amount is bigger than the the seat capacity");
            }
            _ocuppied = value;
        }
    }

    [GraphQLDescription("Available capacity for this seat, it depends on the SeatType, allows to set different capacities when is a banch or else")]
    public int Capacity
    {
        get => _capacity;
        set
        {
            switch (SeatType)
            {
                case SeatType.Single:
                case SeatType.OfficeChair:
                case SeatType.BeachBed:
                case SeatType.ConferenceChair:
                    _capacity = 1;
                    break;
                case SeatType.Double:
                    _capacity = 2;
                    break;
                case SeatType.Triple:
                    _capacity = 3;
                    break;
                case SeatType.Bench:
                    if (value <= 3)
                    {
                        throw new Exception("Seat capacity is incorrect because is unconsistent with the SeatType");
                    }
                    _capacity = value;
                    break;
                default:
                    _capacity = 0;
                    break;
            }
        }
    }
}