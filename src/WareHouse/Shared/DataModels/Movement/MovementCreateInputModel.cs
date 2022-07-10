namespace LasMarias.WareHouse.Domain.DataModels.Movement;

using HotChocolate;
using LasMarias.WareHouse.Domain.Models;

[GraphQLDescription("basic data to create a new movement")]
public class MovementCreateInputModel
{
    [GraphQLDescription("amount moved products")]
    public decimal Amount { get; set; }

    [GraphQLDescription("product price at the moment of the movement")]
    public Optional<decimal> Price { get; set; }

    [GraphQLDescription("description of the movement")]
    public Optional<string> Description { get; set; }

    [GraphQLDescription("id of the user that made the user")]
    public string ApplicationUserId { get; set; }

    [GraphQLDescription("id of the product vendor if needed")]
    public Optional<long> VendorId { get; set; }

    [GraphQLDescription("stand where this product was moved to")]
    public StandType StandType { get; set; }

    [GraphQLDescription("movement type entrance, exit")]
    public MovementType MovementType { get; set; }
}