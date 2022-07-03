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

public partial class BaseMutation<TCreateInputModel>
{
    private readonly IMapper _mapper;

    public string CreateOperationName = "";

    public BaseMutation(IMapper mapper)
    {

    }

    

}