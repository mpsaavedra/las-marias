namespace LasMarias.Domain.DataModels.PriceHistory;

public class PriceHistoryUpdateInputModel
{
    public long Id { get; set; }

    public Optional<long> ProductId { get; set; }

    public Optional<decimal> OldPrice { get; set; }

    public Optional<decimal> NewPrice { get; set; }

    public Optional<string> ApplicationUserId { get; set; }
}