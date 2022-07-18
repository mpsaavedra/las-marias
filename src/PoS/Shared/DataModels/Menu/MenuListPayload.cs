namespace LasMarias.PoS.Domain.DataModels.Menu;

public class MenuListPayload
{
    public IQueryable<Models.Menu>? Payload { get; set; }
}