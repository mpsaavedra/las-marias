namespace LasMarias.Domain.DataModels.MenuPlate;

public class MenuPlateUpdateInputModel
{
    public Optional<long> PlateId { get; set; }

    public Optional<long> MenuId { get; set; }
}