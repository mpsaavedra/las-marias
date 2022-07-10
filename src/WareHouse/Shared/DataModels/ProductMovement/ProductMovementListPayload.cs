namespace LasMarias.WareHouse.Domain.DataModels.ProductMovement;

using System.Linq;
using LasMarias.WareHouse.Domain.Models;

public partial class ProductMovementListPayload 
{
    public IQueryable<ProductMovement>? Payload { get; set; }
}