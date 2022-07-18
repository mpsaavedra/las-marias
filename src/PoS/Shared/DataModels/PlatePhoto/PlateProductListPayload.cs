namespace LasMarias.PoS.Domain.PlatePhoto;

public class PlatePhotoListPayload
{
    public IQueryable<Models.PlatePhoto>? Payload { get; set; }
}