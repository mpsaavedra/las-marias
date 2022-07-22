namespace LasMarias.Domain.DataModels.Product;

[GraphQLDescription("basic data to create a new product")]
public class ProductCreateInputModel
{
#pragma warning disable CS8618
    [GraphQLDescription("name of the product")]
    public string Name { get; set; }
#pragma warning restore CS8618

    [GraphQLDescription("description about the product")]
    public Optional<string> Description { get; set; }

    [GraphQLDescription("note about the product")]
    public Optional<string> Note { get; set; }

    [GraphQLDescription("product's buuy price")]
    public decimal Price { get; set; }

    [GraphQLDescription("product's sale price")]
    public decimal SellingPrice { get; set; }

    [GraphQLDescription("amount of products in the warehouse")]
    public Optional<decimal> Amount { get; set; }

    [GraphQLDescription("minimal level of product in the stock, mark a re-order message")]
    public Optional<decimal> ReOrderLevel { get; set; }

    [GraphQLDescription("id of the measure unit")]
    public Optional<long> MeasureUnitId { get; set; }

    [GraphQLDescription("list of id of attributes")]
    public Optional<ICollection<long>> AttributesIds { get; set; }

    [GraphQLDescription("list of ids of categories")]
    public Optional<ICollection<long>> CategoriesIds { get; set; }

    [GraphQLDescription("list of ids of product photos")]
    public Optional<ICollection<long>> ProductPhotosId { get; set; }

    [GraphQLDescription("list of ids of the product brands relations")]
    public Optional<ICollection<long>> ProductBrandsId { get; set; }
}