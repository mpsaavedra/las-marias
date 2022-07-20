namespace LasMarias.Domain.DataModels.Movement;

[GraphQLDescription("basic data to update a movement")]
public class MovementUpdateInputModel
{
    [GraphQLDescription("id of the movement to update")]
    public long Id { get; set; }

    [GraphQLDescription("amount of products moved")]
    public Optional<decimal> Amount { get; set; }

    [GraphQLDescription("price of the product at the moment of the movement")]
    public Optional<decimal> Price { get; set; }

    [GraphQLDescription("movement description")]
    public Optional<string> Description { get; set; }

    [GraphQLDescription("id of the user that made the movement")]
    public Optional<string> ApplicationUserId { get; set; }

    [GraphQLDescription("id of the vendor")]
    public Optional<long> VendorId { get; set; }

    [GraphQLDescription("stand where the product as moved to")]
    public Optional<StandType> StandType { get; set; }

    [GraphQLDescription("type of movement")]
    public Optional<MovementType> MovementType { get; set; }
}