namespace LasMarias.PoS.Domain.DataModels.ProductPhoto;

using System.Collections.Generic;
using LasMarias.PoS.Domain.Models;

public partial class ProductPhotoListPayload 
{
    public IQueryable<ProductPhoto> Payload { get; set; }
}