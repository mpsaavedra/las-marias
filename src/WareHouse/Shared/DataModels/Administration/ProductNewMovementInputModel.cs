namespace LasMarias.WareHouse.Domain.DataModels.Administration;

using HotChocolate;
using LasMarias.WareHouse.Domain.Models;

[GraphQLDescription("basic required data to register a new product movement")]
public class ProductNewMovementInputModel
{
    [GraphQLDescription("id of moved product")]
    public long ProductId { get; set; }

    [GraphQLDescription("type of movement entrance, exit, etc")]
    public MovementType MovementType { get; set; }

    [GraphQLDescription("amout of moved products")]
    public decimal Amount { get; set; }

    [GraphQLDescription("price of the product at the time of the movement")]
    public decimal Price { get; set; }

    [GraphQLDescription("description about this movement")]
    public Optional<string> Description { get; set; }

    [GraphQLDescription("id of the user this user that made this movement")]
    public string ApplicationUserId { get; set; }

    [GraphQLDescription("id of the product vendor")]
    public Optional<long> VendorId { get; set; }

    [GraphQLDescription("stand where this product was moved to")]
    public Optional<StandType> StandType { get; set; }
}