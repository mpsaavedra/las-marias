namespace LasMarias.Domain.DataModels.Seat;

public class SeatUpdateInputModel
{
    public long Id { get; set; }
    
    public Optional<string> Code { get; set; }

    public Optional<long> TableId { get; set; }

    public Optional<long> StandId { get; set; }

    public Optional<string> InventaryNumber { get; set; }

    public Optional<SeatType> SeatType { get; set; }

    public Optional<int> Occupied { get; set; }
}