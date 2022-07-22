namespace LasMarias.Domain.DataModels.PriceHistory;

public class PriceHistoryCreateInputModel
{
    public long ProductId { get; set; }

    public Optional<decimal> OldPrice { get; set; }

    public decimal NewPrice { get; set; }

#pragma warning disable CS8618
    public string ApplicationUserId { get; set; }
#pragma warning restore CS8618
}