namespace LasMarias.WareHouse.Domain.DataModels.Category;

public class CategoryUpdateInputModel
{
    public long Id { get; set; }
    
    public string? Name { get; set; }

    public string? Code { get; set; }

    public bool? Enable { get; set; }

    public long? ParentCagetoryId { get; set; }
}