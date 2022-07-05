namespace LasMarias.WareHouse.Domain.DataModels.Brand;

using HotChocolate;
public class BrandUpdateInputModel
{
    public long Id { get; set; }
    public Optional<string?> Name { get; set; }

    public Optional<bool?> Enable  { get; set; }
}