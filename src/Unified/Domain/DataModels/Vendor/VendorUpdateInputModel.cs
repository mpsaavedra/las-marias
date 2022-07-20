namespace LasMarias.Domain.DataModels.Vendor;


[GraphQLDescription("basic data to update a vendor, which it could also be a provider")]
public partial class VendorUpdateInputModel
{
    [GraphQLDescription("id of vendor to update")]
    public long Id { get; set; }

    [GraphQLDescription("name of vendor")]
    public Optional<string> Name { get; set; }

    [GraphQLDescription("description")]
    public Optional<string> Description { get; set; }

    [GraphQLDescription("if true is available to the system")]
    public Optional<bool> Enable { get; set; }
}