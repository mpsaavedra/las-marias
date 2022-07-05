namespace LasMarias.WareHouse.Queries;

using Orun;
using Orun.Extensions;
using Orun.Services;
using Orun.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using LasMarias.WareHouse.Data;
using LasMarias.WareHouse.Domain.Models;
using LasMarias.WareHouse.Domain.Repositories;
using LasMarias.WareHouse.Domain.DataModels.Movement;
using LasMarias.WareHouse.Extensions;
using Serilog;

[ExtendObjectType("Query")]
[GraphQLDescription("Movements queries")]
public partial class MovementQuery
{
    [UseFirstOrDefault]
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [GraphQLDescription("List all movements")]
    public async Task<IQueryable<Movement>> GetMovements(
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            Log.Debug("Retrieving movements list");
            var data = new MovementListPayload();
            var fail = await chain.ExecuteAsyncChain<MovementListPayload, bool>(
                "get-movement-list", 
                data);
            return await Task.FromResult(data.Payload!);
        }
        catch (Exception e)
        {
            Insist.Throw<Exception>(e.FullMessage());
            throw;
        }
    }
}