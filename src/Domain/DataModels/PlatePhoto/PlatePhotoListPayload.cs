namespace LasMarias.Domain.DataModels.PlatePhoto;

public class PlatePhotoListPayload
{
    public IQueryable<Domain.Models.PlatePhoto>? Payload { get; set; }
}