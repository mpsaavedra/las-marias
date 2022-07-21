namespace LasMarias.Domain.DataModels.Stand;

public class StandListPayload
{
    public IQueryable<Domain.Models.Stand>? Payload { get; set; }
}