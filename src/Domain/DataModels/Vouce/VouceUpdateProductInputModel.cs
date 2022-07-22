namespace LasMarias.Domain.DataModels.Vouce;

[GraphQLDescription("Data to delete a product movement from a Vouce")]
public class VouceUpdateProductInputModel
{
    [GraphQLDescription("Id of existing Vouce")]
    public long VouceId { get; set; }

    [GraphQLDescription("Basic information to update the product")]
    public Optional<MovementCreateInputModel> Product { get; set; }

    public Optional<ICollection<VouceProductMovementInputModel>> ProductMovements { get; set; }
}