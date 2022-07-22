namespace LasMarias.Domain.Models;

[GraphQLDescription("Product vendor, describes a common product provider or distributor")]
public partial class Vendor : BusinessEntity<long>
{
    public Vendor()
    {
        Movements = new HashSet<Movement>();
        VendorBrands = new HashSet<VendorBrand>();
        Name = "";
    }

    [GraphQLDescription("this vendor Id")]
    public long VendorId { get; set; }

    [GraphQLDescription("name of the vendor")]
    public string Name { get; set; }

    [GraphQLDescription("description about this vendor")]
    public string? Description { get; set; }

    [GraphQLDescription("if true this vendor is available to the system")]
    public bool Enable { get; set; }

    [GraphQLDescription("List of movements made by this vendor")]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<Movement>? Movements { get; set; }

    [GraphQLDescription("List of relations that describes the brands distributed by this vendor")]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<VendorBrand>? VendorBrands { get; set; }
}