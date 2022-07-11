namespace LasMarias.WareHouse.Domain.Models;

using Orun.Domain;
using System.Text.Json.Serialization;
using HotChocolate;
using HotChocolate.Data;

[GraphQLDescription("Product photo relations")]
public partial class ProductPhoto : BusinessEntity<long>
{
    public ProductPhoto()
    {
        DefaultPhoto = false;
    }

    [GraphQLDescription("product photo id")]
    public long ProductPhotoId { get; set; }

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

    [GraphQLDescription("Id of product")]
    public long ProductId { get; set; }

    [GraphQLDescription("Product this photo is related to")]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual Product? Product { get; set; }
}