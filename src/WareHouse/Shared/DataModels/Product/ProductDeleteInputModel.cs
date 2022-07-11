namespace LasMarias.WareHouse.Domain.DataModels.Product;

using HotChocolate;

[GraphQLDescription("basic data to delete a product")]
public class ProductDeleteInputModel
{
    [GraphQLDescription("id of product to delte")]
    public long Id { get; set; }
}