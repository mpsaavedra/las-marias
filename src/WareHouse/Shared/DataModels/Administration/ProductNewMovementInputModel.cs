namespace LasMarias.WareHouse.Domain.DataModels.Administration;

using HotChocolate;
using LasMarias.WareHouse.Domain.Models;

public class ProductNewMovementInputModel
{
    public long ProductId { get; set; }

    public MovementType MovementType { get; set; }

    public decimal Amount { get; set; }

    public decimal Price { get; set; }

    public Optional<string> Description { get; set; }

    public string ApplicationUserId { get; set; }

    public Optional<long> VendorId { get; set; }

    public Optional<StandType> StandType { get; set; }
}