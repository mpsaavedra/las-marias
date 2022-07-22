namespace LasMarias.Domain.Models;

[GraphQLDescription("product brand data")]
public partial class Brand : BusinessEntity<long>
{
    public Brand()
    {
        ProductBrands = new HashSet<ProductBrand>();
        VendorBrands = new HashSet<VendorBrand>();
        Name = "";
        Enable = true;
    }

    public Brand(string name)
    {
        Name = name;
        ProductBrands = new HashSet<ProductBrand>();
        VendorBrands = new HashSet<VendorBrand>();
        Enable = true;
    }

    [GraphQLDescription("id of the brand")]
    public long BrandId { get; set; }

    [GraphQLDescription("name of the brand")]
    public string Name { get; set; }

    [GraphQLDescription("if true is available in the system")]
    public bool Enable { get; set; }

    [GraphQLDescription("list of products of this brand")]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<ProductBrand>? ProductBrands { get; set; }

    [GraphQLDescription("list of vendors that provide this brand")]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<VendorBrand>? VendorBrands { get; set; }
}