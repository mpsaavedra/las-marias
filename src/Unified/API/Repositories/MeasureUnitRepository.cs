namespace LasMarias.Repositories;

public class MeasureUnitRepository : Repository<long, MeasureUnit>
{
    public MeasureUnitRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}
