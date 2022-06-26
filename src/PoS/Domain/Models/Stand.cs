using System.Collections;
using System.Collections.Generic;
using Orun.Domain;
using System.Text.Json.Serialization;
using HotChocolate.Data;

namespace LasMarias.PoS.Domain.Models;

/// <summary>
/// A stand refers to a simple area, like Bar, Pools, Restaurant, etc
/// </summary>
public partial class Stand : BusinessEntity<long>
{
    public Stand()
    {
        Tables = new HashSet<Table>();
        Seats = new HashSet<Seat>();
        Available = true;
    }


    public long StandId { get; set;}

    public string Name { get; set; }

    /// <summary>
    /// if false, this stand is not available this field could be used in 
    /// case the stand could be rent like for a private party or so
    /// </summary>
    public bool Available { get; set; }

    /// <summary>
    /// sometimes this value could be used to determ the availabe seats in 
    /// a given stand, this is because for example: a bar could only had 
    /// had chairs close to the 
    /// </summary>
    public StandType StandType { get; set; }

    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<Table> Tables { get; set; }

    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<Seat> Seats { get; set; }
}