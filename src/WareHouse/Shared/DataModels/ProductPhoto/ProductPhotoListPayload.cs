namespace LasMarias.WareHouse.Domain.DataModels.ProductPhoto;

using System.Linq;
using LasMarias.WareHouse.Domain.Models;

public partial class ProductPhotoListPayload 
{
    public IQueryable<ProductPhoto>? Payload { get; set; }
}