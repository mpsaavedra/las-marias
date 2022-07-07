namespace LasMarias.WareHouse.Domain.DataModels.Category;

using HotChocolate;

public class CategoryUpdateInputModel
{
    public long Id { get; set; }
    
    public Optional<string> Name { get; set; }

    public Optional<string> Code { get; set; }

    public Optional<bool> Enable { get; set; }

    public Optional<long> ParentCagetoryId { get; set; }
}