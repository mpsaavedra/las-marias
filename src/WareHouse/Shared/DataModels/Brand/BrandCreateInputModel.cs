namespace LasMarias.WareHouse.Domain.DataModels.Brand;

using HotChocolate;

public class BrandCreateInputModel
{
    public string Name { get; set; }

    public Optional<bool> Enable  { get; set; }
}