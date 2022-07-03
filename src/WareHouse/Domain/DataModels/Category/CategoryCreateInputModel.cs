namespace LasMarias.WareHouse.Domain.DataModels.Category;

public class CategoryCreateInputModel
{
    public string Name { get; set; }

    public string? Code { get; set; }

    public bool? Enable { get; set; }

    public long? ParentCategoryId { get; set; }
}