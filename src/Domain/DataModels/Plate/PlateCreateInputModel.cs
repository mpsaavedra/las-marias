namespace LasMarias.Domain.DataModels.Plate;

public class PlateCreateInputModel
{
#pragma warning disable CS8618
    public string Name { get; set; }
#pragma warning restore CS8618

    public Optional<string> Description { get; set; }

    public Optional<string> Recipe { get; set; }

    public Optional<decimal> SellingPrice { get; set; }

    public Optional<bool> Available { get; set; }
}