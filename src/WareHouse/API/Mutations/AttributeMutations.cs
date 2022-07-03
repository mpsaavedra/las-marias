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
using LasMarias.WareHouse.Domain.DataModels.Attribute;
using LasMarias.WareHouse.Extensions;
using Serilog;
using AutoMapper;

[ExtendObjectType("Mutation")]
public partial class AttributeMutations
{
    public async Task<LasMarias.WareHouse.Domain.Models.Attribute> AttributeCreate(AttributeCreateInputModel input,
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("Creating a new attribute");
            var data = await chain.ExecuteAsyncChain<AttributeCreateInputModel, 
                LasMarias.WareHouse.Domain.Models.Attribute>(
                "attribute-create", input
            );
            return await Task.FromResult(data);
        }
        catch (Exception ex)
        {
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }         
    }

    public async Task<LasMarias.WareHouse.Domain.Models.Attribute> AttributeUpdate(long id, AttributeUpdateInputModel input,
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug($"Updating attribute {id}");
            var data = await chain.ExecuteAsyncChain<AttributeUpdateInputModel, 
                LasMarias.WareHouse.Domain.Models.Attribute>(
                "attribute-update", input
            );
            return await Task.FromResult(data);
        }
        catch (System.Exception ex)
        {
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }

    public async Task<bool> AttributeDelete(long id, 
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug($"Deleting attribute {id}");
            var response = await chain.ExecuteAsyncChain<long, bool>(
                "attribute-delete", id
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