namespace LasMarias.WareHouse.Mutations;

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
using AutoMapper;

[ExtendObjectType("Mutation")]
public partial class VendorMutations
{
    [GraphQLDescription("creates a new vendor")]
    public async Task<LasMarias.WareHouse.Domain.Models.Vendor> VendorCreate(VendorCreateInputModel input,
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("Creating a new Vendor");
            var data = await chain.ExecuteAsyncChain<VendorCreateInputModel, 
                LasMarias.WareHouse.Domain.Models.Vendor>(
                "vendor-create", input
            );
            return await Task.FromResult(data);
        }
        catch (Exception ex)
        {
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }         
    }

    [GraphQLDescription("update a vendor")]
    public async Task<LasMarias.WareHouse.Domain.Models.Vendor> VendorUpdate(VendorUpdateInputModel input,
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug($"Updating Vendor {input.Id}");
            var data = await chain.ExecuteAsyncChain<VendorUpdateInputModel, 
                LasMarias.WareHouse.Domain.Models.Vendor>(
                "vendor-update", input
            );
            return await Task.FromResult(data);
        }
        catch (System.Exception ex)
        {
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }

    [GraphQLDescription("deletes a vendor")]
    public async Task<bool> VendorDelete(VendorDeleteInputModel input, 
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug($"Deleting Vendor {input.Id}");
            var response = await chain.ExecuteAsyncChain<VendorDeleteInputModel, bool>(
                "vendor-delete", input
            );
            return response;
        }
        catch (Exception ex)
        {
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }
}