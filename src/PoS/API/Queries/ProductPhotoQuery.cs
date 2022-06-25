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
using LasMarias.PoS.Domain.DataModels.ProductPhoto;
using LasMarias.PoS.Extensions;
using Serilog;

[ExtendObjectType(Name = "Query")]
[GraphQLDescription("Product photos queries")]
public partial class ProductPhotoQuery
{
    [UseFirstOrDefault]
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [GraphQLDescription("List all available product photos")]
    public async Task<IQueryable<ProductPhoto>> GetProductPhotos(
        [Service] IChainOfResponsibilityService chain
    )
    {
         try
        {
            Log.Debug("Retrieving Product photos list");
            var data = new ProductPhotoListPayload();
            var fail = await chain.ExecuteAsyncChain<ProductPhotoListPayload, bool>(
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