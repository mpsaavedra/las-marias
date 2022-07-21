namespace LasMarias.Domain.DataModels.MenuPlate;

public class MenuPlateListPayload
{
    public IQueryable<Domain.Models.MenuPlate>? Payload { get; set; }
}