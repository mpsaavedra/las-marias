namespace LasMarias.Domain.DataModels.PlateProduct;

public class PlateProductCreateInputModel
{
    public long PlateId { get; set; }

    public long ProductId { get; set; }

    public decimal Amount { get; set; }

    public Optional<long> MeaasureUnitId { get; set; }
}