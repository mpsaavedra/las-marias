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
using LasMarias.WareHouse.Domain.DataModels.Brand;
using LasMarias.WareHouse.Extensions;
using Serilog;
using AutoMapper;

[ExtendObjectType("Mutation")]
public partial class BrandMutations
{
    [GraphQLDescription("create a new brand")]
    public async Task<LasMarias.WareHouse.Domain.Models.Brand> BrandCreate(BrandCreateInputModel input,
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("Creating a new Brand");
            var data = await chain.ExecuteAsyncChain<BrandCreateInputModel, 
                LasMarias.WareHouse.Domain.Models.Brand>(
                "brand-create", input
            );
            return await Task.FromResult(data);
        }
        catch (Exception ex)
        {
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }         
    }

    [GraphQLDescription("update an existing brand")]
    public async Task<LasMarias.WareHouse.Domain.Models.Brand> BrandUpdate(BrandUpdateInputModel input,
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug($"Updating Brand {input.Id}");
            var data = await chain.ExecuteAsyncChain<BrandUpdateInputModel, 
                LasMarias.WareHouse.Domain.Models.Brand>(
                "brand-update", input
            );
            return await Task.FromResult(data);
        }
        catch (System.Exception ex)
        {
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }

    [GraphQLDescription("deletes an existing brand")]
    public async Task<bool> BrandDelete(BrandDeleteInputModel input, 
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug($"Deleting Brand {input.Id}");
            var response = await chain.ExecuteAsyncChain<BrandDeleteInputModel, bool>(
                "brand-delete", input
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