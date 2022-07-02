namespace LasMarias.WareHouse.Domain.Models;

using Orun.Domain;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public partial class Brand : BusinessEntity<long>
{
    public Brand()
    {
        ProductBrands = new HashSet<ProductBrand>();
        VendorBrands = new HashSet<VendorBrand>();
    }

    public long BrandId { get; set; }

    public string Name { get; set; }

    public bool Enable { get; set; }

    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<ProductBrand> ProductBrands { get; set; }

    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<VendorBrand> VendorBrands { get; set; }
}