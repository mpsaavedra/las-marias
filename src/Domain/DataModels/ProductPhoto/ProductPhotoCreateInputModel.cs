namespace LasMarias.Domain.DataModels.ProductPhoto;

public class ProductPhotoCreateInputModel
{
    public long ProductId { get; set; }

    public Optional<string> ContentType { get; set; }

    public Optional<string> Data { get; set; }

    public Optional<string> PhotoUrl { get; set; }

    public Optional<string> DesignColor { get; set; }

    public Optional<bool> DefaultColor { get; set; }
}