namespace LasMarias.Domain.Models;

/// <summary>
/// A stand refers to a simple area, like Bar, Pools, Restaurant, etc
/// </summary>
[GraphQLDescription("Describes a stand in the business, this stands could be consider as local or areas")]
public partial class Stand : BusinessEntity<long>
{
    public Stand()
    {
        Tables = new HashSet<Table>();
        Seats = new HashSet<Seat>();
        Enable = true;
        Reserved = false;
        Name = "";
    }

    [GraphQLDescription("Id of stand")]
    public long StandId { get; set; }

    [GraphQLDescription("Name of the stand")]
    public string Name { get; set; }

    [GraphQLDescription("if true is available to use in the system")]
    public bool Enable { get; set; }

    [GraphQLDescription("if true stand is reserved for an event")]
    public bool Reserved { get; set; }

    [GraphQLDescription("if true stand is available to be reserved or receive clients")]
    public bool Available => Enable && !Reserved;

    /// <summary>
    /// sometimes this value could be used to determ the availabe seats in 
    /// a given stand, this is because for example: a bar could only had 
    /// had chairs close to the 
    /// </summary>
    [GraphQLDescription("Stand type")]
    public StandType StandType { get; set; }

    [GraphQLDescription("list of tables of this stand, it could be none")]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<Table>? Tables { get; set; }

    [GraphQLDescription("Seats available for this Stand")]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<Seat>? Seats { get; set; }
}