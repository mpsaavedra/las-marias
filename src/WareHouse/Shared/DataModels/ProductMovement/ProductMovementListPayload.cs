namespace LasMarias.WareHouse.Domain.DataModels.ProductMovement;

using System.Linq;
using HotChocolate;
using LasMarias.WareHouse.Domain.Models;

[GraphQLDescription("returns a lis tof product movement relation")]
public partial class ProductMovementListPayload 
{
    [GraphQLDescription("list of product movement")]
    public IQueryable<ProductMovement>? Payload { get; set; }
}