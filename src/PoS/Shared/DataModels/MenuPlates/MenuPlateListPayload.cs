namespace LasMarias.PoS.Domain.DataModels.MenuPlates;

public class MenuPlateListPayload
{
    public IQueryable<Models.MenuPlate>? Payload { get; set; }
}