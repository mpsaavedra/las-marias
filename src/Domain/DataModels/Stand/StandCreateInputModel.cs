namespace LasMarias.Domain.DataModels.Stand;

public class StandCreateInputModel
{
#pragma warning disable CS8618
    public string Name { get; set; }
#pragma warning restore CS8618

    public Optional<bool> Enable { get; set; }

    public Optional<bool> Reserved { get; set; }

    public Optional<StandType> StandType { get; set; }

    public Optional<ICollection<long>> TableIds { get; set; }

    public Optional<ICollection<long>> SeatIds { get; set; }
}