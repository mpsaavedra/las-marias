namespace LasMarias.Domain.DataModels.Plate;

public class PlateUpdateInputModel
{
    public Optional<string> Name { get; set; }

    public Optional<string> Description { get; set; }

    public Optional<string> Recipe { get; set; }

    public Optional<decimal> SellingPrice { get; set; }

    public Optional<bool> Available { get; set; }
}