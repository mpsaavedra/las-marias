using System.Collections.Generic;
using Orun.Domain;
using System.Text.Json.Serialization;
using HotChocolate.Data;

namespace LasMarias.PoS.Domain.Models;

public partial class Seat : BusinessEntity<long>
{
    public long SeatId { get; set; }

    public string? Code { get; set; }
    
    public SeatType SeatType { get; set; }

    public bool IsOccupied { get; set; }

    public long TableId { get; set; }

    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual Table? Table { get; set; }

    public long StandId { get; set; }

    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual Stand? Stand { get; set; }
}