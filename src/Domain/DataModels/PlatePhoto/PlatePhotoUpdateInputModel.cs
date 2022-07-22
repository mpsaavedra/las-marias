namespace LasMarias.Domain.DataModels.PlatePhoto;

public class PlatePhotoUpdateInputModel
{
    public Optional<string> ContentType { get; set; }

    public Optional<string> Date { get; set; }

    public Optional<string> PhotoUrl { get; set; }

    public Optional<string> DesignColor { get; set; }

    public Optional<bool> DefaultPhoto { get; set; }

    public Optional<long> PlateId { get; set; }
}