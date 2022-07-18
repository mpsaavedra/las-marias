namespace LasMarias.PoS.Domain.DataModels.PlatePhoto;

public class PlatePhotoListPayload
{
    public IQueryable<Models.PlatePhoto>? Payload { get; set; }
}