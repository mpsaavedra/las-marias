namespace LasMarias.PoS.Domain.DataModels.Plate;

public class PlateListPayload
{
    public IQueryable<Models.Plate>? Payload { get; set; }
}