namespace LasMarias.WareHouse.Domain.Models;

using Orun.Domain;

public partial class MeasureUnit : BusinessEntity<long>
{
    public MeasureUnit()
    {
        Products = new HashSet<Product>();
        Cast = Cast.ToString; // default cast to string
    }

    public long MeasureUnitId { get; set; }

    public string Name { get; set; }

    public string Code { get; set; }

    public Cast Cast { get; set; }

    public bool Enable { get; set; }

    public virtual ICollection<Product> Products { get; set; }
}