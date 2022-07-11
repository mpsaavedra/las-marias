namespace LasMarias.WareHouse.Domain.DataModels.ProductBrand;

using System.Linq;
using HotChocolate;
using LasMarias.WareHouse.Domain.Models;

[GraphQLDescription("returns a list of product brand relations")]
public partial class ProductBrandListPayload 
{
    [GraphQLDescription("list of product brands")]
    public IQueryable<ProductBrand>? Payload { get; set; }
}