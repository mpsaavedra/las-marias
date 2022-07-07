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
using LasMarias.WareHouse.Domain.DataModels.MeasureUnit;
using LasMarias.WareHouse.Extensions;
using Serilog;
using AutoMapper;

[ExtendObjectType("Mutation")]
public partial class MeasureUnitMutations
{
    public async Task<LasMarias.WareHouse.Domain.Models.MeasureUnit> MeasureUnitCreate(MeasureUnitCreateInputModel input,
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("Creating a new MeasureUnit");
            var data = await chain.ExecuteAsyncChain<MeasureUnitCreateInputModel, 
                LasMarias.WareHouse.Domain.Models.MeasureUnit>(
                "measure-unit-create", input
            );
            return await Task.FromResult(data);
        }
        catch (Exception ex)
        {
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }         
    }

    public async Task<LasMarias.WareHouse.Domain.Models.MeasureUnit> MeasureUnitUpdate(MeasureUnitUpdateInputModel input,
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug($"Updating MeasureUnit {input.Id}");
            var data = await chain.ExecuteAsyncChain<MeasureUnitUpdateInputModel, 
                LasMarias.WareHouse.Domain.Models.MeasureUnit>(
                "measure-unit-update", input
            );
            return await Task.FromResult(data);
        }
        catch (System.Exception ex)
        {
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }

    public async Task<bool> MeasureUnitDelete(long id, 
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug($"Deleting Measure Unit {id}");
            var response = await chain.ExecuteAsyncChain<long, bool>(
                "measure-unit-delete", id
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