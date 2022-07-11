namespace LasMarias.WareHouse.Domain.DataModels.Vendor;

using HotChocolate;

[GraphQLDescription("basic information to create a new Vendor, it could be called to as provider")]
public partial class VendorCreateInputModel
{
    [GraphQLDescription("name")]
    public string Name { get; set; }

    [GraphQLDescription("description")]
    public Optional<string> Description { get; set; }
}