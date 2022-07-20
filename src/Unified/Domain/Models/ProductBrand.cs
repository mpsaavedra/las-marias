namespace LasMarias.Domain.Models;

[GraphQLDescription("Describe a relation between product and brand")]
public partial class ProductBrand : BusinessEntity<long>
{
    [GraphQLDescription("id of the product brand")]
    public long ProductBrandId { get; set; }

    [GraphQLDescription("id of the product")]
    public long ProductId { get; set; }

    [GraphQLDescription("Id of the brand")]
    public long BrandId { get; set; }

    [GraphQLDescription("Produt of brand")]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual Product Product { get; set; }

    [GraphQLDescription("Brand of the product")]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual Brand Brand { get; set; }
}