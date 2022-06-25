namespace LasMarias.PoS.Repositories;

using AutoMapper;
using Orun.BuildingBlocks.Domain;
using LasMarias.PoS.Data;
using LasMarias.PoS.Domain.Models;
using LasMarias.PoS.Domain.Repositories;

public partial class SeatRepository : Repository<long, Seat>
{
    public SeatRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {
        
    }
}