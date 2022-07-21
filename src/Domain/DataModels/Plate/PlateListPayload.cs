namespace LasMarias.Domain.DataModels.Plate;

public class PlateListPayload
{
    public IQueryable<Domain.Models.Plate>? Payload { get; set; }
}