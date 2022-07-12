namespace LasMarias.PoS.Domain.DataModels.Table;

using System.Linq;
using LasMarias.PoS.Domain.Models;

[GraphQLDescription("returns a list of tables")]
public partial class TableListPayload
{
    [GraphQLDescription("list of tables")]
    public IQueryable<Table>? Payload { get; set; }
}