namespace LasMarias.Domain.DataModels.Table;

public class TableUpdateInputModel
{
    public Optional<string> Name { get; set; }

    public Optional<long> StandId { get; set; }

    public Optional<string> InventaryNumber { get; set; }
}