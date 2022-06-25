namespace LasMarias.PoS.Domain.DataModels.ProductPhoto;

using System.Linq;
using LasMarias.PoS.Domain.Models;

public partial class ProductPhotoListPayload 
{
    public IQueryable<ProductPhoto>? Payload { get; set; }
}