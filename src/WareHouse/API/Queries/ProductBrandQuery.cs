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
using LasMarias.WareHouse.Domain.DataModels.ProductBrand;
using LasMarias.WareHouse.Extensions;
using Serilog;

[ExtendObjectType("Query")]
[GraphQLDescription("Product Attribute queries")]
public partial class ProductBrandQuery
{
    [UseFirstOrDefault]
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [GraphQLDescription("List all available product brands relations")]
    public async Task<IQueryable<ProductBrand>> GetProductBrands(
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            Log.Debug("Retrieving attributes names list");
            var data = new ProductBrandListPayload();
            var fail = await chain.ExecuteAsyncChain<ProductBrandListPayload, bool>(
                "get-product-brands-list", 
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