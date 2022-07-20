namespace LasMarias.Domain.DataModels.Vouce;


[GraphQLDescription("Required data to add a new product movement to an existing Vouce")]
public class VouceAddProductMovementInputModel
{
    [GraphQLDescription("Id of existing Vouce")]
    public long VouceId { get; set; }

    [GraphQLDescription("Basic information to create the product and added to the vouce")]
    public VouceProductMovementInputModel? Product { get; set; }
}