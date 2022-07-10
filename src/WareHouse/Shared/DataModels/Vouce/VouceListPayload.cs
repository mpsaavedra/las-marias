namespace LasMarias.WareHouse.Domain.DataModels.Vouce;

using System.Linq;
using LasMarias.WareHouse.Domain.Models;

public partial class VouceListPayload
{
    public IQueryable<Vouce>? Payload { get; set; }
}