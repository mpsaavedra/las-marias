namespace LasMarias.PoS.Domain.DataModels.MenuPlates;

public class MenuPlatesListPayload
{
    public IQueryable<Models.MenuPlate>? Payload { get; set; }
}