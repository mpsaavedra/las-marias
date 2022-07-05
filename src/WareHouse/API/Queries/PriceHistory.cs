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
using LasMarias.WareHouse.Domain.DataModels.PriceHistory;
using LasMarias.WareHouse.Extensions;
using Serilog;

[ExtendObjectType("Query")]
[GraphQLDescription("PriceHistory queries")]
public partial class PriceHistoryQuery
{
    [UseFirstOrDefault]
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [GraphQLDescription("List all available price histories")]
    public async Task<IQueryable<PriceHistory>> GetPriceHistory(
        [Service] IChainOfResponsibilityService chain
    )
    {
         try
        {
            Log.Debug("Retrieving price histories names list");
            var data = new PriceHistoryListPayload();
            var fail = await chain.ExecuteAsyncChain<PriceHistoryListPayload, bool>(
                "get-price-history-list", 
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