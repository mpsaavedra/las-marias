namespace LasMarias.PoS.Queries;

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
using LasMarias.PoS.Data;
using LasMarias.PoS.Domain.Models;
using LasMarias.PoS.Domain.Repositories;
using LasMarias.PoS.Domain.DataModels.Product;
using LasMarias.PoS.Extensions;
using Serilog;

[ExtendObjectType(Name = "Query")]
[GraphQLDescription("Product queries")]
public partial class ProductQuery
{
    [UseFirstOrDefault]
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [GraphQLDescription("List all available products")]
    public async Task<IQueryable<Product>> GetProduct(
        [Service] IChainOfResponsibilityService chain
    )
    {
         try
        {
            Log.Debug("Retrieving Products names list");
            var data = new ProductListPayload();
            var fail = await chain.ExecuteAsyncChain<ProductListPayload, bool>(
                "get-products-list", 
                data);
            return await Task.FromResult(data.Payload);
        }
        catch (Exception e)
        {
            Insist.Throw<Exception>(e.FullMessage());
            throw;
        }
    }
}