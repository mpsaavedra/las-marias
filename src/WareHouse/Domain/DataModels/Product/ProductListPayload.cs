namespace LasMarias.WareHouse.Domain.DataModels.Product;

using System.Linq;
using LasMarias.WareHouse.Domain.Models;

public partial class ProductListPayload 
{
    public IQueryable<Product>? Payload { get; set; }
}