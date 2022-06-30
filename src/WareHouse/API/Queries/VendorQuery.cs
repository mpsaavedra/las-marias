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
using LasMarias.WareHouse.Domain.DataModels.Vendor;
using LasMarias.WareHouse.Extensions;
using Serilog;

[ExtendObjectType("Query")]
[GraphQLDescription("Product Attribute queries")]
public partial class VendorQuery
{
    [UseFirstOrDefault]
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [GraphQLDescription("List all available vendors")]
    public async Task<IQueryable<Vendor>> GetVendors(
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            Log.Debug("Retrieving vendor list");
            var data = new VendorListPayload();
            var fail = await chain.ExecuteAsyncChain<VendorListPayload, bool>(
                "get-vendors-brands-list", 
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