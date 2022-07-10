namespace LasMarias.WareHouse.Domain.DataModels.Vouce;

using HotChocolate;
using LasMarias.WareHouse.Domain.Models;

public class VouceProductMovementInputModel
{
    public long ProductId { get; set; }
    
    public decimal Amount { get; set; }

    public decimal Price { get; set; }

    public Optional<string> Description { get; set; }

    public Optional<long> VendorId { get; set; }
}