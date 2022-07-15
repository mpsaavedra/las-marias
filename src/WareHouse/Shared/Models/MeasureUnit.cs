namespace LasMarias.WareHouse.Domain.Models;

[GraphQLDescription("Measure unit used in product quiantities")]
public partial class MeasureUnit : BusinessEntity<long>
{
    public MeasureUnit()
    {
        Products = new HashSet<Product>();
        Cast = Cast.ToString; // default cast to string
        Name = "";
        Code = "";
    }

    public MeasureUnit(string name)
    {
        Products = new HashSet<Product>();
        Cast = Cast.ToString; // default cast to string
        Name = name;
        Code = "";
    }

    public MeasureUnit(string name, string code)
    {
        Products = new HashSet<Product>();
        Cast = Cast.ToString; // default cast to string
        Name = name;
        Code = code;
    }

    [GraphQLDescription("id of the measure unit")]
    public long MeasureUnitId { get; set; }

    [GraphQLDescription("human readable name")]
    public string Name { get; set; }

    [GraphQLDescription("measure unit simple code")]
    public string Code { get; set; }

    [GraphQLDescription("describe how to cast the value")]
    public Cast Cast { get; set; }

    [GraphQLDescription("if true is used in the system")]
    public bool Enable { get; set; }

    [GraphQLDescription("list of products that uses this Measure unit")]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<Product> Products { get; set; }
}