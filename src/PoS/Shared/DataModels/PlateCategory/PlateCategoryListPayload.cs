namespace LasMarias.PoS.Domain.DataModels.PlateCategory;

public class PlateCategoryListPayload
{
    public IQueryable<Models.PlateCategory>? Payload { get; set; }
}