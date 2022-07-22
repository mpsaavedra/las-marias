namespace LasMarias.Domain.DataModels.MenuPlate;

public class MenuPlateUpdateInputModel
{
    public long Id { get; set; }

    public Optional<long> PlateId { get; set; }

    public Optional<long> MenuId { get; set; }
}