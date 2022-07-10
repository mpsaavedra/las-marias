namespace LasMarias.WareHouse.Domain.DataModels.AttributeName;

using HotChocolate;
using LasMarias.WareHouse.Domain.Models;

public class AttributeNameCreateInputModel
{
    public AttributeNameCreateInputModel()
    {
        Enable = true;
    }

    public AttributeNameCreateInputModel(string name)
    {
        Name = name;
        Enable = true;
    }

    public AttributeNameCreateInputModel(string name, bool enable)
    {
        Name = name;
        Enable = enable;
    }

    public string Name { get; set; }

    public Optional<bool> Enable { get; set; }
}