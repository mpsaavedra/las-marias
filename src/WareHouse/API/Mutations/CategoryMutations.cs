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
using LasMarias.WareHouse.Domain.DataModels.Category;
using LasMarias.WareHouse.Extensions;
using Serilog;
using AutoMapper;

[ExtendObjectType("Mutation")]
public partial class CategoryMutations
{
    [GraphQLDescription("create a new category")]
    public async Task<LasMarias.WareHouse.Domain.Models.Category> CategoryCreate(CategoryCreateInputModel input,
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("Creating a new Category");
            var data = await chain.ExecuteAsyncChain<CategoryCreateInputModel, 
                LasMarias.WareHouse.Domain.Models.Category>(
                "category-create", input
            );
            return await Task.FromResult(data);
        }
        catch (Exception ex)
        {
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }         
    }

    [GraphQLDescription("update an existing category")]
    public async Task<LasMarias.WareHouse.Domain.Models.Category> CategoryUpdate(CategoryUpdateInputModel input,
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug($"Updating Category {input.Id}");
            var data = await chain.ExecuteAsyncChain<CategoryUpdateInputModel, 
                LasMarias.WareHouse.Domain.Models.Category>(
                "category-update", input
            );
            return await Task.FromResult(data);
        }
        catch (System.Exception ex)
        {
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }

    [GraphQLDescription("delete an existing category")]
    public async Task<bool> CategoryDelete(CategoryDeleteInputModel input, 
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug($"Deleting Category {input.Id}");
            var response = await chain.ExecuteAsyncChain<CategoryDeleteInputModel, bool>(
                "category-delete", input
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