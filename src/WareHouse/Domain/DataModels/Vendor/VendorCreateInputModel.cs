namespace LasMarias.WareHouse.Domain.DataModels.Vendor;

using HotChocolate;

public partial class VendorCreateInputModel
{
    public string Name { get; set; }

    public Optional<string> Description { get; set; }
}