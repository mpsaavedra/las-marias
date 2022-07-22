namespace LasMarias.Domain.Models;

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
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual Vendor? Vendor { get; set; }

    [GraphQLDescription("Brand that the vendor distributes")]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual Brand? Brand { get; set; }
}