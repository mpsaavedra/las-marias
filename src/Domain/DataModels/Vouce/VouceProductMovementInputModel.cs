namespace LasMarias.Domain.DataModels.Vouce;

public class VouceProductMovementInputModel
{
    public long ProductId { get; set; }

    public MovementCreateInputModel? Movement { get; set; }
}