namespace LasMarias.Domain.DataModels.Stand;

public class StandUpdateInputModel
{
    public long Id { get; set; }

    public Optional<string> Name { get; set; }

    public Optional<bool> Enable { get; set; }

    public Optional<bool> Reserved { get; set; }

    public Optional<StandType> StandType { get; set; }

    public Optional<ICollection<long>> TableIds { get; set; }

    public Optional<ICollection<long>> SeatIds { get; set; }
}