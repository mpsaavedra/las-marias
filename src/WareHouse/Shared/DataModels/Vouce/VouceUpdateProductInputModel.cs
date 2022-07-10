namespace LasMarias.WareHouse.Domain.DataModels.Vouce;

using HotChocolate;

[GraphQLDescription("Data to delete a product movement from a Vouce")]
public class VouceUpdateProductInputModel
{
    [GraphQLDescription("Id of existing Vouce")]
    public long VouceId { get; set; }

    [GraphQLDescription("Basic information to update the product")]
    public VouceProductMovementInputModel Product { get; set; }
}