namespace LasMarias.Domain.DataModels.Seat;

public class SeatCreateInputModel
{
    public Optional<string> Code { get; set; }

    public Optional<long> TableId { get; set; }

    public Optional<long> StandId { get; set; }

    public Optional<string> InventaryNumber { get; set; }

    public SeatType SeatType { get; set; }
}