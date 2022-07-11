namespace LasMarias.PoS.Domain.DataModels.Table;

using System.Linq;
using LasMarias.PoS.Domain.Models;

public partial class TableListPayload
{
    public IQueryable<Table>? Payload { get; set; }
}