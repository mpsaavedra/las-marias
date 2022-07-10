namespace LasMarias.WareHouse.Domain.DataModels.AttributeName;

using System.Linq;
using HotChocolate;
using LasMarias.WareHouse.Domain.Models;

[GraphQLDescription("response data of the attribute name list")]
public partial class AttributeNameListPayload
{
    [GraphQLDescription("list of name of attributes")]
    public IQueryable<AttributeName>? Payload { get; set; }
}