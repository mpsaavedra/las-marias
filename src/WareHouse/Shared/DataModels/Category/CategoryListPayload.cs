namespace LasMarias.WareHouse.Domain.DataModels.Category;

using System.Linq;
using HotChocolate;
using LasMarias.WareHouse.Domain.Models;

[GraphQLDescription("returns the list of categories")]
public partial class CategoryListPayload
{
    [GraphQLDescription("list of category")]
    public IQueryable<Category>? Payload { get; set; }
}