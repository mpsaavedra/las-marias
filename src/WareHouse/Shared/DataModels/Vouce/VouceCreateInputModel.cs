namespace LasMarias.WareHouse.Domain.DataModels.Vouce;

using HotChocolate;
using LasMarias.WareHouse.Domain.Models;

[GraphQLDescription("basic data to create a new vouce")]
public partial class VouceCreateInputModel
{
    public VouceCreateInputModel()
    {
        ProductMovements = new HashSet<VouceProductMovementInputModel>();
    }

    [GraphQLDescription("simple note about the vouce")]
    public Optional<string> Note { get; set; }

    [GraphQLDescription("id of user that emit the vouce")]
    public string ApplicationUserId { get; set; }

    [GraphQLDescription("movemen type, entrance, exit, etc.")]
    public MovementType MovementType { get; set; }

    [GraphQLDescription("stand this vouce was emmited to")]
    public Optional<StandType> StandType { get; set; }

    [GraphQLDescription("list of product movements basic data to include in the vouce")]
    public ICollection<VouceProductMovementInputModel> ProductMovements { get; set; }
}