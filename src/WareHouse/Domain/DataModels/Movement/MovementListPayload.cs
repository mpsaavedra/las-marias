namespace LasMarias.WareHouse.Domain.DataModels.Movement;

using System.Linq;
using LasMarias.WareHouse.Domain.Models;

public partial class MovementListPayload
{
    public IQueryable<Movement>? Payload { get; set; }
}