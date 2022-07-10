namespace LasMarias.WareHouse.Domain.Models;

using Orun.Domain;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using HotChocolate;
using HotChocolate.Data;

[GraphQLDescription("Describes the relation of brands distributed by vendor")]
public partial class VendorBrand : BusinessEntity<long>
{
    [GraphQLDescription("Id of the Vendor/brand relation")]
    public long VendorBrandId { get; set; }

    [GraphQLDescription("Id of vendor")]
    public long VendorId { get; set; }

    [GraphQLDescription("Id of the brand")]
    public long BrandId { get; set; }

    [GraphQLDescription("Vendor that distributes the brand")]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual Vendor Vendor { get; set; }

    [GraphQLDescription("Brand that the vendor distributes")]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual Brand Brand { get; set; }
}