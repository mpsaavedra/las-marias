namespace LasMarias.WareHouse.Domain.DataModels.Vouce;

using System.Linq;
using HotChocolate;
using LasMarias.WareHouse.Domain.Models;

[GraphQLDescription("returns a list of vouces")]
public partial class VouceListPayload
{
    [GraphQLDescription("list of vouces")]
    public IQueryable<Vouce>? Payload { get; set; }
}