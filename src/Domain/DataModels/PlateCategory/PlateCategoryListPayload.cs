namespace LasMarias.Domain.DataModels.PlateCategory;

public class PlateCategoryListPayload
{
    public IQueryable<Domain.Models.PlateCategory>? Payload { get; set; }
}