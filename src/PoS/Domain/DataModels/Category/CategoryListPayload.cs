namespace LasMarias.PoS.Domain.DataModels.Category;

using System.Collections.Generic;
using LasMarias.PoS.Domain.Models;

public partial class CategoryListPayload
{
    public IQueryable<Category> Payload { get; set; }
}