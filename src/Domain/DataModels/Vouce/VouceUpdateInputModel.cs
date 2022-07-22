namespace LasMarias.Domain.DataModels.Vouce;

public class VouceUpdateInputModel
{
    public long Id { get; set; }

    [GraphQLDescription("id of user that emit the vouce")]
    public Optional<string> ApplicationUserId { get; set; }

    [GraphQLDescription("simple note about the vouce")]
    public Optional<string> Note { get; set; }

    [GraphQLDescription("movemen type, entrance, exit, etc.")]
    public MovementType MovementType { get; set; }

    [GraphQLDescription("stand this vouce was emmited to")]
    public Optional<StandType> StandType { get; set; }

    public Optional<ICollection<VouceProductMovementInputModel>> ProductMovements { get; set; }
}