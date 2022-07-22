namespace LasMarias.Domain.DataModels.MeasureUnit;

public class MenuCreateInputModel
{
#pragma warning disable CS8618
    public string Name { get; set; }
#pragma warning restore CS8618

    public Optional<string> Description { get; set; }

    public Optional<bool> Available { get; set; }

    public Optional<bool> Offer { get; set; }

    public StandType StandType { get; set; }

    public Optional<decimal> SellingPrice { get; set; }
}