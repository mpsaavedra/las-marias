namespace LasMarias.PoS.Domain.DataModels.Seat;

using System.Linq;
using LasMarias.PoS.Domain.Models;

public partial class SeatListPayload
{
    public IQueryable<Seat>? Payload { get; set; }
}