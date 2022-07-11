namespace LasMarias.WareHouse.Domain.DataModels.Vendor;

using HotChocolate;

[GraphQLDescription("basic data to delete a vendor")]
public class VendorDeleteInputModel
{
    [GraphQLDescription("id of vendor to delete")]
    public long Id { get; set; }
}