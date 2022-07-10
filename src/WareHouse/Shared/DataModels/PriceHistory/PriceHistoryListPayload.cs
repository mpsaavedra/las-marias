namespace LasMarias.WareHouse.Domain.DataModels.PriceHistory;

using System.Linq;
using LasMarias.WareHouse.Domain.Models;

public partial class PriceHistoryListPayload
{
    public IQueryable<PriceHistory>? Payload { get; set; }
}