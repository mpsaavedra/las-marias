namespace LasMarias.WareHouse.Domain.DataModels.Vendor;

using HotChocolate;

public partial class VendorUpdateInputModel
{
    public long Id { get; set; }

    public Optional<string> Name { get; set; }

    public Optional<string> Description { get; set; }

    public Optional<bool> Enable { get; set; }
}