namespace LasMarias.PoS.Repositories;

using AutoMapper;
using Orun.BuildingBlocks.Domain;
using LasMarias.PoS.Data;
using LasMarias.PoS.Domain.Models;
using LasMarias.PoS.Domain.Repositories;

public partial class TableRepository : Repository<long, Table>, ITableRepository
{
    public TableRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}