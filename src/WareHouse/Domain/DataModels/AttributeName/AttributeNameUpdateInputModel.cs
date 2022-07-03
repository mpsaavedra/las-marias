namespace LasMarias.WareHouse.Domain.DataModels.AttributeName;

using HotChocolate;
using LasMarias.WareHouse.Domain.Models;

public partial class AttributeNameUpdateInputModel
{
    public string? Name { get; set; }

    public bool? Enable { get; set; }
}