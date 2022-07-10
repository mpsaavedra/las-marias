namespace LasMarias.WareHouse.Domain.DataModels.Movement;

using System.Linq;
using HotChocolate;
using LasMarias.WareHouse.Domain.Models;

[GraphQLDescription("retrieve a list of movements")]
public partial class MovementListPayload
{
    [GraphQLDescription("lsit of movements")]
    public IQueryable<Movement>? Payload { get; set; }
}