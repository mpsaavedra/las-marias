namespace LasMarias.PoS.Domain.DataModels.Stand;

using System.Linq;
using LasMarias.PoS.Domain.Models;

[GraphQLDescription("returns a list of stands")]
public partial class StandListPayload
{
    [GraphQLDescription("list of Stands")]
    public IQueryable<Stand>? Payload { get; set; }
}