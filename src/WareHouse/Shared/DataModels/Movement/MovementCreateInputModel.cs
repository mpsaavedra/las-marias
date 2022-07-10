namespace LasMarias.WareHouse.Domain.DataModels.Movement;

using HotChocolate;
using LasMarias.WareHouse.Domain.Models;

public class MovementCreateInputModel
{
    public decimal Amount { get; set; }

    public Optional<decimal> Price { get; set; }

    public Optional<string> Description { get; set; }

    public string ApplicationUserId { get; set; }

    public Optional<long> VendorId { get; set; }

    public StandType StandType { get; set; }

    public MovementType MovementType { get; set; }
}