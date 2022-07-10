namespace LasMarias.WareHouse.Domain.DataModels.Vouce;

using HotChocolate;

[GraphQLDescription("Data to delete a product movement from a Vouce")]
public class VouceRemoveProductInputModel
{
    [GraphQLDescription("Vouce id to remove product")]
    public long VouceId { get; set; }


    [GraphQLDescription("Product movement to remove from Vouce")]
    public long ProductMovementId { get; set; }
}