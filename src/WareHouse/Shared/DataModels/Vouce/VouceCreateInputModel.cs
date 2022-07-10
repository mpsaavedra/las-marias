namespace LasMarias.WareHouse.Domain.DataModels.Vouce;

using HotChocolate;
using LasMarias.WareHouse.Domain.Models;

public partial class VouceCreateInputModel
{
    public VouceCreateInputModel()
    {
        ProductMovements = new HashSet<VouceProductMovementInputModel>();
    }

    public Optional<string> Note { get; set; }

    public string ApplicationUserId { get; set; }

    public MovementType MovementType { get; set; }

    public Optional<StandType> StandType { get; set; }

    public ICollection<VouceProductMovementInputModel> ProductMovements { get; set; }
}