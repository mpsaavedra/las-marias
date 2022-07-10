namespace LasMarias.WareHouse.Domain.DataModels.Movement;

using HotChocolate;
using LasMarias.WareHouse.Domain.Models;

public class MovementUpdateInputModel
{
    public long Id { get; set; }
    
    public Optional<decimal> Amount { get; set; }

    public Optional<decimal> Price { get; set; }

    public Optional<string> Description { get; set; }

    public Optional<string> ApplicationUserId { get; set; }

    public Optional<long> VendorId { get; set; }

    public Optional<StandType> StandType { get; set; }

    public Optional<MovementType> MovementType { get; set; }
}