namespace LasMarias.WareHouse.Domain.DataModels.Movement;

using HotChocolate;

[GraphQLDescription("basic data to delete a movement")]
public class MovementDeleteInputModel
{
    [GraphQLDescription("id of the movement to delete")]
    public long Id { get; set; }
}