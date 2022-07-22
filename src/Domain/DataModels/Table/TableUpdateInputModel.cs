namespace LasMarias.Domain.DataModels.Table;

public class TableUpdateInputModel
{
    public long Id { get; set; }

    public Optional<string> Name { get; set; }

    public Optional<long> StandId { get; set; }

    public Optional<string> InventaryNumber { get; set; }
}