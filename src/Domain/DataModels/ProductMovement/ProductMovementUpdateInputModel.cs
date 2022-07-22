namespace LasMarias.Domain.DataModels.ProductMovement;

public class ProductMovementUpdateInputModel
{
    public Optional<long> ProductId { get; set; }

    public Optional<long> MovementId { get; set; }

    public Optional<long> VouceId { get; set; }
}