namespace LasMarias.WareHouse.Domain.DataModels.AttributeName;

using System.Linq;
using LasMarias.WareHouse.Domain.Models;

public partial class AttributeNameListPayload
{
    public IQueryable<AttributeName>? Payload { get; set; }
}