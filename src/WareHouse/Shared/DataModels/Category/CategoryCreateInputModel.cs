namespace LasMarias.WareHouse.Domain.DataModels.Category;

using HotChocolate;

public class CategoryCreateInputModel
{
    public string Name { get; set; }

    public Optional<string> Code { get; set; }

    public Optional<bool> Enable { get; set; }

    public Optional<long> ParentCategoryId { get; set; }
}