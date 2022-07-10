namespace LasMarias.WareHouse.Domain.DataModels.Product;

using System.Linq;
using HotChocolate;
using LasMarias.WareHouse.Domain.Models;

[GraphQLDescription("returns a list of products")]
public partial class ProductListPayload 
{
    [GraphQLDescription("list of products")]
    public IQueryable<Product>? Payload { get; set; }
}