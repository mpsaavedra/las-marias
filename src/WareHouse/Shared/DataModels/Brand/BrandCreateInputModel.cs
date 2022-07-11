namespace LasMarias.WareHouse.Domain.DataModels.Brand;

using HotChocolate;

[GraphQLDescription("basic data to create a new brand")]
public class BrandCreateInputModel
{
    [GraphQLDescription("name of the brand")]
    public string Name { get; set; }

    [GraphQLDescription("if true brand is available to the system")]
    public Optional<bool> Enable  { get; set; }
}