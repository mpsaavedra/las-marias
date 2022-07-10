namespace LasMarias.WareHouse.Domain.DataModels.Attribute;

using System.Linq;
using LasMarias.WareHouse.Domain.Models;
using HotChocolate;

[GraphQLDescription("list of attributes")]
public partial class AttributeListPayload
{
    [GraphQLDescription("list of attributes")]
    public IQueryable<Attribute>? Payload { get; set; }
}