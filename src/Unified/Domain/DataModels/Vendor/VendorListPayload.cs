namespace LasMarias.Domain.DataModels.Vendor;

[GraphQLDescription("returns a list of vendors")]
public partial class VendorListPayload
{
    [GraphQLDescription("list of vendors")]
    public IQueryable<Models.Vendor>? Payload { get; set; }
}