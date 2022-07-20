namespace LasMarias.Domain.DataModels.Vendor;


[GraphQLDescription("basic information to create a new Vendor, it could be called to as provider")]
public partial class VendorCreateInputModel
{
    public VendorCreateInputModel()
    {
        Name = "";
    }

    [GraphQLDescription("name")]
    public string Name { get; set; }

    [GraphQLDescription("description")]
    public Optional<string> Description { get; set; }
}