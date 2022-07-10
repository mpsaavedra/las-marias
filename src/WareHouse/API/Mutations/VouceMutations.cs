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
using LasMarias.WareHouse.Domain.DataModels.Vouce;
using LasMarias.WareHouse.Extensions;
using Serilog;
using AutoMapper;

[ExtendObjectType("Mutation")]
public partial class VouceMutations
{
    [GraphQLDescription("Creates a new Vouce")]
    public async Task<Vouce> VouceCreate(VouceCreateInputModel input,
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("Creating a new attribute name");
            var data = await chain.ExecuteAsyncChain<VouceCreateInputModel, Vouce>(
                "vouce-create", input
            );
            return await Task.FromResult(data);
        }
        catch (Exception ex)
        {
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }         
    }

    [GraphQLDescription("Adds a new product to an existing vouce")]
    public async Task<Vouce> VouceAddProduct(VouceAddProductMovementInputModel input,
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug($"Adding product to vouce {input.VouceId}");
            var data = await chain.ExecuteAsyncChain<VouceAddProductMovementInputModel, Vouce>(
                "vouce-add-product-movement", input
            );
            return await Task.FromResult(data);
        }
        catch (System.Exception ex)
        {
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }

    [GraphQLDescription("Remove a new product to an existing vouce")]
    public async Task<Vouce> VouceRemoveProduct(VouceRemoveProductInputModel input,
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug($"Adding product to vouce {input.VouceId}");
            var data = await chain.ExecuteAsyncChain<VouceRemoveProductInputModel, Vouce>(
                "vouce-remove-product-movement", input
            );
            return await Task.FromResult(data);
        }
        catch (System.Exception ex)
        {
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }

    [GraphQLDescription("Delete an existing Vouce")]
    public async Task<bool> VouceDelete(VouceDeleteInputModel input, 
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug($"Deleting attribute name {input.Id}");
            var response = await chain.ExecuteAsyncChain<VouceDeleteInputModel, bool>(
                "vouce-delete", input
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