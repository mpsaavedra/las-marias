namespace LasMarias.WareHouse.Domain.DataModels.Movement;

using LasMarias.WareHouse.Domain.Models;

public class MovementUpdateInputModel
{
    public long Id { get; set; }
    
    public decimal? Amount { get; set; }

    public decimal? Price { get; set; }

    public string? Description { get; set; }

    public string? ApplicationUserId { get; set; }

    public long? VendorId { get; set; }

    public StandType? StandType { get; set; }

    public MovementType? MovementType { get; set; }
}