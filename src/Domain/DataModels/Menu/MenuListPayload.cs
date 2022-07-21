namespace LasMarias.Domain.DataModels.Menu;

public class MenuListPayload
{
    public IQueryable<Domain.Models.Menu>? Payload { get; set; }
}