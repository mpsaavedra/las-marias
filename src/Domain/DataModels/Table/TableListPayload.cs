namespace LasMarias.Domain.DataModels.Table;

public class TableListPayload
{
    public IQueryable<Domain.Models.Table>? Payload { get; set; }
}