namespace LasMarias.Domain.DataModels.Vendor;

[GraphQLDescription("basic data to delete a vendor")]
public class VendorDeleteInputModel
{
    [GraphQLDescription("id of vendor to delete")]
    public long Id { get; set; }
}