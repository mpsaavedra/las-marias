namespace LasMarias.WareHouse.Domain.Models;

using Orun.Domain;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using HotChocolate;
using HotChocolate.Data;

public partial class VendorBrand : BusinessEntity<long>
{
    public long VendorBrandId { get; set; }

    public long VendorId { get; set; }

    public long BrandId { get; set; }

    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual Vendor Vendor { get; set; }

    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual Brand Brand { get; set; }
}