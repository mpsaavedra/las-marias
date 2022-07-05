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
using LasMarias.WareHouse.Domain.DataModels.ProductMovement;
using LasMarias.WareHouse.Extensions;
using Serilog;

[ExtendObjectType("Query")]
[GraphQLDescription("Product ProductMovement queries")]
public partial class ProductMovementQuery
{
    [UseFirstOrDefault]
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [GraphQLDescription("List all available Product Movements")]
    public async Task<IQueryable<LasMarias.WareHouse.Domain.Models.ProductMovement>> GetProductMovements(
        [Service] IChainOfResponsibilityService chain
    )
    {
         try
        {
            Log.Debug("Retrieving ProductMovements names list");
            var data = new ProductMovementListPayload();
            var fail = await chain.ExecuteAsyncChain<ProductMovementListPayload, bool>(
                "get-product-movement-list", 
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