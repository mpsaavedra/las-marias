namespace LasMarias.WareHouse.Domain.DataModels.AttributeName;

using HotChocolate;
using LasMarias.WareHouse.Domain.Models;

public partial class AttributeNameUpdateInputModel
{
    public long id { get; set; }
    public Optional<string> Name { get; set; }

    public Optional<bool> Enable { get; set; }
}