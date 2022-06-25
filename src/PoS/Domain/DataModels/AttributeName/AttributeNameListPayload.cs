namespace LasMarias.PoS.Domain.DataModels.AttributeName;

using System.Collections.Generic;
using LasMarias.PoS.Domain.Models;

public partial class AttributeNameListPayload
{
    public IQueryable<AttributeName> Payload { get; set; }
}