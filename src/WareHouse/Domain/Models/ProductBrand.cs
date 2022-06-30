namespace LasMarias.WareHouse.Domain.Models;

using Orun.Domain;
using System.Collections.Generic;

public partial class ProductBrand : BusinessEntity<long>
{
    public long ProductBrandId { get; set; }

    public long ProductId { get; set; }

    public long BrandId { get; set; }

    // public virtual Product Product { get; set; }

    // public virtual Brand Brand { get; set; }
}