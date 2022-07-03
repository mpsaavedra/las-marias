namespace LasMarias.WareHouse.Domain.DataModels.Vendor;

public partial class VendorUpdateInputModel
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public bool? Enable { get; set; }
}