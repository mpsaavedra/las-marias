namespace LasMarias.PoS.Domain.DataModels.Stand;

using System.Linq;
using LasMarias.PoS.Domain.Models;

public partial class StandListPayload
{
    public IQueryable<Stand>? Payload { get; set; }
}