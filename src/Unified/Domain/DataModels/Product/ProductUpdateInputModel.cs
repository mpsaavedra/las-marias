namespace LasMarias.Domain.DataModels.Product;


[GraphQLDescription("basic information to update a product")]
public class ProductUpdateInputModel
{
    [GraphQLDescription("id of product to change")]
    public long Id { get; set; }

    [GraphQLDescription("name")]
    public Optional<string> Name { get; set; }

    [GraphQLDescription("description")]
    public Optional<string> Description { get; set; }

    [GraphQLDescription("simple note about product")]
    public Optional<string> Note { get; set; }

    [GraphQLDescription("product's buy price")]
    public Optional<decimal> Price { get; set; }

    [GraphQLDescription("product's sale price")]
    public Optional<decimal> SellingPrice { get; set; }

    [GraphQLDescription("amount of product in the warehouse")]
    public Optional<decimal> Amount { get; set; }

    [GraphQLDescription("minimal order level to send a re-order message tomanager")]
    public Optional<decimal> ReOrderLevel { get; set; }

    [GraphQLDescription("ids of products attributes")]
    public ICollection<long>? AttributesIds { get; set; }

    [GraphQLDescription("ids of products categories")]
    public ICollection<long>? CategoriesIds { get; set; }

    [GraphQLDescription("ids of product photos")]
    public ICollection<long>? ProductPhotosIds { get; set; }

    [GraphQLDescription("ids of product brands")]
    public ICollection<long>? ProductBrandsIds { get; set; }
}