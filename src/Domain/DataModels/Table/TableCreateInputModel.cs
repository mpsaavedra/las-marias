namespace LasMarias.Domain.DataModels.Table;

public class TableCreateInputModel
{
#pragma warning disable CS8618
    public string Name { get; set; }
#pragma warning restore CS8618

    public Optional<long> StandId { get; set; }

    public Optional<string> InventaryNumber { get; set; }
}