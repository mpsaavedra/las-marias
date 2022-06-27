namespace LasMarias.WareHouse.Domain.DataModels.Attribute;

using System.Linq;
using LasMarias.WareHouse.Domain.Models;

public partial class MovementListPayload
{
    public IQueryable<Movement>? Payload { get; set; }
}