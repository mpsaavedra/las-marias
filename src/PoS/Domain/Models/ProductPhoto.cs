namespace LasMarias.PoS.Domain.Models;

using Orun.Domain;

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

    public virtual Product Product { get; set; }
}