namespace LasMarias.PoS.Domain.DataModels.Category;

public class CategoryListPayload
{
    public IQueryable<Models.Category>? Payload { get; set; }
}