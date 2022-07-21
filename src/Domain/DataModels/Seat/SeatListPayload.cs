namespace LasMarias.Domain.DataModels.Seat;

public class SeatListPayload
{
    public IQueryable<Domain.Models.Seat>? Payload { get; set; }
}