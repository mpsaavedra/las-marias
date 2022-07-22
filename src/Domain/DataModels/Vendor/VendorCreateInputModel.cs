namespace LasMarias.Domain.DataModels.Vendor;


[GraphQLDescription("basic information to create a new Vendor, it could be called to as provider")]
public partial class VendorCreateInputModel
{
#pragma warning disable CS8618
    [GraphQLDescription("name")]
    public string Name { get; set; }
#pragma warning restore CS8618

    [GraphQLDescription("description")]
    public Optional<string> Description { get; set; }
}