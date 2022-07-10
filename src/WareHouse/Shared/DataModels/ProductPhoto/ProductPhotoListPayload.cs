namespace LasMarias.WareHouse.Domain.DataModels.ProductPhoto;

using System.Linq;
using HotChocolate;
using LasMarias.WareHouse.Domain.Models;

[GraphQLDescription("returns a list of product photo relations")]
public partial class ProductPhotoListPayload 
{
    [GraphQLDescription("list of product photos")]
    public IQueryable<ProductPhoto>? Payload { get; set; }
}