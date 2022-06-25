namespace LasMarias.PoS.Domain.Models;

using Orun.Domain;
using System.Text.Json.Serialization;
using HotChocolate.Data;

public partial class ProductPhoto : BusinessEntity<long>
{
    public long ProductPhotoId { get; set; }

    public byte[] Photo { get; set; }

    public string PhotoUrl { get; set; }

    /// <summary>
    /// used if for a better UX
    /// </summary>
    public string? DesignColor { get; set; }

    public bool IsInitialPhoto { get; set; }

    public long ProductId { get; set; }

    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual Product Product { get; set; }
}