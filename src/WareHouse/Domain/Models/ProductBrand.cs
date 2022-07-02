namespace LasMarias.WareHouse.Domain.Models;

using Orun.Domain;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using HotChocolate;
using HotChocolate.Data;

public partial class ProductBrand : BusinessEntity<long>
{
    public long ProductBrandId { get; set; }

    public long ProductId { get; set; }

    public long BrandId { get; set; }

    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual Product Product { get; set; }

    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual Brand Brand { get; set; }
}