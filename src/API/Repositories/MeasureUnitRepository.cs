namespace LasMarias.Repositories;

public class MeasureUnitRepository : Repository<long, MeasureUnit>, IMeasureUnitRepository
{
    public MeasureUnitRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}
