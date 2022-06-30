namespace LasMarias.WareHouse.Domain.Models;

using Orun.Domain;
using System.Collections.Generic;

public partial class Brand : BusinessEntity<long>
{
    public Brand()
    {
        // ProductBrands = new HashSet<ProductBrand>();
        // VendorBrands = new HashSet<VendorBrand>();
    }

    public long BrandId { get; set; }

    public string Name { get; set; }

    public bool Enable { get; set; }

    // public virtual ICollection<ProductBrand> ProductBrands { get; set; }

    // public virtual ICollection<VendorBrand> VendorBrands { get; set; }
}