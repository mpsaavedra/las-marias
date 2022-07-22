namespace LasMarias.Domain.DataModels.Menu;

public class MenuUpdateInputModel
{
    public Optional<string> Name { get; set; }

    public Optional<string> Description { get; set; }

    public Optional<bool> Available { get; set; }

    public Optional<bool> Offer { get; set; }

    public StandType StandType { get; set; }

    public Optional<decimal> SellingPrice { get; set; }
}