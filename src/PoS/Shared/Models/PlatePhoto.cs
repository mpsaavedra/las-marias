namespace LasMarias.PoS.Domain.Models;

// TODO: move this entity into the restaurant service
[GraphQLDescription("Plate photo")]
public partial class PlatePhoto : BusinessEntity<long>
{
    public PlatePhoto()
    {
        DefaultPhoto = false;
    }

    [GraphQLDescription("id of plate photo")]
    public long PlatePhotoId { get; }

    [GraphQLDescription("photo's  bytes array")]
    public byte[]? Photo { get; set; }

    [GraphQLDescription("photo url in the static server if used")]
    public string? PhotoUrl { get; set; }

    /// <summary>
    /// used if for a better UX
    /// </summary>
    [GraphQLDescription("sugested photo background/location color")]
    public string? DesignColor { get; set; }

    [GraphQLDescription("if true this photo will be used as default photo")]
    public bool DefaultPhoto { get; set; }

    [GraphQLDescription("if of the plate")]
    public long? PlateId { get; set; }

    [GraphQLDescription("plate this photo belong")]
    public virtual Plate? Plate { get; set; }
}