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
using LasMarias.WareHouse.Domain.DataModels.Movement;
using LasMarias.WareHouse.Extensions;
using Serilog;
using AutoMapper;

[ExtendObjectType("Mutation")]
public partial class MovementMutations
{
    public async Task<LasMarias.WareHouse.Domain.Models.Movement> MovementCreate(MovementCreateInputModel input,
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("Creating a new Movement");
            var data = await chain.ExecuteAsyncChain<MovementCreateInputModel, 
                LasMarias.WareHouse.Domain.Models.Movement>(
                "movement-create", input
            );
            return await Task.FromResult(data);
        }
        catch (Exception ex)
        {
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }         
    }

    public async Task<LasMarias.WareHouse.Domain.Models.Movement> MovementUpdate(MovementUpdateInputModel input,
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug($"Updating Movement {input.Id}");
            var data = await chain.ExecuteAsyncChain<MovementUpdateInputModel, 
                LasMarias.WareHouse.Domain.Models.Movement>(
                "movement-update", input
            );
            return await Task.FromResult(data);
        }
        catch (System.Exception ex)
        {
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }

    public async Task<bool> MovementDelete(long id, 
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug($"Deleting Movement {id}");
            var response = await chain.ExecuteAsyncChain<long, bool>(
                "movement-delete", id
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