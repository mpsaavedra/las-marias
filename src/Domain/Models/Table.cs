namespace LasMarias.Domain.Models;

public partial class Table : BusinessEntity<long>
{
    public Table()
    {
        Seats = new HashSet<Seat>();
        Name = "";
    }

    [GraphQLDescription("id of table")]
    public long TableId { get; set; }

    [GraphQLDescription("Table name like, table1, table2")]
    public string Name { get; set; }

    [GraphQLDescription("if true table is ocuppied by clients")]
    public bool IsOcuppied { get; set; }

    [GraphQLDescription("Seats available for this table")]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<Seat>? Seats { get; set; }

    public long StandId { get; set; }

    [GraphQLDescription("Stand this table belongs to")]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual Stand? Stand { get; set; }

    [GraphQLDescription("inventary number")]
    public string? InventaryNumber { get; set; }
}