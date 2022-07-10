namespace LasMarias.WareHouse.Domain.DataModels.AttributeName;

using HotChocolate;
using LasMarias.WareHouse.Domain.Models;

[GraphQLDescription("basic data to create an attribute name")]
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

    [GraphQLDescription("name of the attribute name")]
    public string Name { get; set; }

    [GraphQLDescription("if true is available to the system")]
    public Optional<bool> Enable { get; set; }
}