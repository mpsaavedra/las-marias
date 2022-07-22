namespace LasMarias.Domain.DataModels.Vouce;

[GraphQLDescription("basic data to create a new vouce")]
public partial class VouceCreateInputModel
{
#pragma warning disable CS8618
    [GraphQLDescription("id of user that emit the vouce")]
    public string ApplicationUserId { get; set; }
#pragma warning restore CS8618

    [GraphQLDescription("simple note about the vouce")]
    public Optional<string> Note { get; set; }

    [GraphQLDescription("movemen type, entrance, exit, etc.")]
    public MovementType MovementType { get; set; }

    [GraphQLDescription("stand this vouce was emmited to")]
    public Optional<StandType> StandType { get; set; }

    public Optional<ICollection<VouceProductMovementInputModel>> ProductMovements { get; set; }
}