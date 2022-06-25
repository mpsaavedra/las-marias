using System.Collections.Generic;
using Orun.Domain;
using System.Text.Json.Serialization;
using HotChocolate.Data;

namespace LasMarias.PoS.Domain.Models;

public partial class Seat : BusinessEntity<long>
{
    public long SeatId { get; set; }

    public string Number { get; set; }
    
    public SeatType SeatType { get; set; }

    public long TableId { get; set; }

    public virtual Table? Table { get; set; }

    public long StandId { get; set; }

    public virtual Stand? Stand { get; set; }
}