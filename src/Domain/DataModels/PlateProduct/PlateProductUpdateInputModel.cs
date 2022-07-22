namespace LasMarias.Domain.DataModels.PlateProduct;

public class PlateProductUpdateInputModel
{
    public long Id { get; set; }

    public Optional<long> PlateId { get; set; }

    public Optional<long> ProductId { get; set; }

    public Optional<decimal> Amount { get; set; }

    public Optional<long> MeaasureUnitId { get; set; }
}