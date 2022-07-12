namespace LasMarias.PoS.Domain.DataModels.Seat;

using System.Linq;
using LasMarias.PoS.Domain.Models;

[GraphQLDescription("returns a list of seats")]
public partial class SeatListPayload
{
    [GraphQLDescription("list of seats")]
    public IQueryable<Seat>? Payload { get; set; }
}