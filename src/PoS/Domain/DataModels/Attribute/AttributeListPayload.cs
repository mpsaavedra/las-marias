namespace LasMarias.PoS.Domain.DataModels.Attribute;

using System.Linq;
using LasMarias.PoS.Domain.Models;

public partial class AttributeListPayload
{
    public IQueryable<Attribute>? Payload { get; set; }
}