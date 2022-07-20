namespace LasMarias.Domain.DataModels.ProductMovement;


[GraphQLDescription("returns a lis tof product movement relation")]
public partial class ProductMovementListPayload
{
    [GraphQLDescription("list of product movement")]
    public IQueryable<Models.ProductMovement>? Payload { get; set; }
}