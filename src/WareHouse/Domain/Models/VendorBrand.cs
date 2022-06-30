namespace LasMarias.WareHouse.Domain.Models;

using Orun.Domain;
using System.Collections.Generic;

public partial class VendorBrand : BusinessEntity<long>
{
    public long VendorBrandId { get; set; }

    public long VendorId { get; set; }

    public long BrandId { get; set; }

    // public virtual Vendor Vendor { get; set; }

    // public virtual Brand Brand { get; set; }
}