namespace LasMarias.Domain.DataModels.ProductMovement;

public class ProductMovementCreateInputModel
{
    public long ProductId { get; set; }

    public long MovementId { get; set; }

    public long VouceId { get; set; }
}