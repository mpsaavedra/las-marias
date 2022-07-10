namespace LasMarias.WareHouse.Domain.DataModels.Category;

using System.Linq;
using LasMarias.WareHouse.Domain.Models;

public partial class CategoryListPayload
{
    public IQueryable<Category>? Payload { get; set; }
}