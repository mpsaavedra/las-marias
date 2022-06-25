using System.Collections.Generic;
using Orun.Domain;
using System.Text.Json.Serialization;
using HotChocolate.Data;

namespace LasMarias.PoS.Domain.Models;

public partial class Table : BusinessEntity<long>
{
    public long TableId { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Seat> Seats { get; set; }

    public long StandId { get; set; }

    public virtual Stand? Stand { get; set; }
}