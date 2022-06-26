namespace LasMarias.WareHouse.Domain.DataModels.Attribute;

using System.Linq;
using LasMarias.WareHouse.Domain.Models;

public partial class AttributeListPayload
{
    public IQueryable<Attribute>? Payload { get; set; }
}