namespace LasMarias.WareHouse.Domain.DataModels.Vouce;

using HotChocolate;
using LasMarias.WareHouse.Domain.Models;

[GraphQLDescription("Required data to create a new product movement, data like StandType and MovementType are taken from Vouce data")]
public class VouceProductMovementInputModel
{
    public VouceProductMovementInputModel()
    {
        Amount = 0;
        Price = 0;
        Description = "";
    }

    [GraphQLDescription("Product id to move")]
    public long ProductId { get; set; }
    
    [GraphQLDescription("Amount of product to move")]
    public Optional<decimal> Amount { get; set; }

    [GraphQLDescription("Price of product in the moment to register the movement")]
    public Optional<decimal> Price { get; set; }

    [GraphQLDescription("A simple description about the product")]
    public Optional<string> Description { get; set; }

    [GraphQLDescription("Vendor Id that provide the product")]
    public Optional<long> VendorId { get; set; }
}