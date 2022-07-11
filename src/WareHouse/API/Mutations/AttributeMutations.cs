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
    [GraphQLDescription("create a new attribute")]
    public async Task<Domain.Models.Attribute> AttributeCreate(AttributeCreateInputModel input,
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("Creating a new attribute");
            var data = await chain.ExecuteAsyncChain<AttributeCreateInputModel, 
                Domain.Models.Attribute>(
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

    [GraphQLDescription("update an existing attribute")]
    public async Task<Domain.Models.Attribute> AttributeUpdate(AttributeUpdateInputModel input,
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug($"Updating attribute {input.Id}");
            var data = await chain.ExecuteAsyncChain<AttributeUpdateInputModel, 
                Domain.Models.Attribute>(
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

    [GraphQLDescription("deletes an existing attribute")]
    public async Task<bool> AttributeDelete(AttributeDeleteInputModel input, 
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug($"Deleting attribute {input.Id}");
            var response = await chain.ExecuteAsyncChain<AttributeDeleteInputModel, bool>(
                "attribute-delete", input
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