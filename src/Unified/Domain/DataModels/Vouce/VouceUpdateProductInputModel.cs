namespace LasMarias.Domain.DataModels.Vouce;

[GraphQLDescription("Data to delete a product movement from a Vouce")]
public class VouceUpdateProductInputModel
{
    public VouceUpdateProductInputModel()
    {
        VouceId = 0;
        Product = null;
    }


    public VouceUpdateProductInputModel(long vouceId, VouceProductMovementInputModel product)
    {
        VouceId = vouceId;
        Product = product;
    }


    [GraphQLDescription("Id of existing Vouce")]
    public long VouceId { get; set; }

    [GraphQLDescription("Basic information to update the product")]
    public VouceProductMovementInputModel? Product { get; set; }
}