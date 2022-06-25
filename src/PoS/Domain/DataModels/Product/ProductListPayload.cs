namespace LasMarias.PoS.Domain.DataModels.Product;

using System.Collections.Generic;
using LasMarias.PoS.Domain.Models;

public partial class ProductListPayload 
{
    public IQueryable<Product> Payload { get; set; }
}