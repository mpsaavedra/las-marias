namespace LasMarias.Domain.DataModels.MeasureUnit;

[GraphQLDescription("returns a list of measure units")]
public class MeasureUnitListPayload
{
    [GraphQLDescription("list of measure units")]
    public IQueryable<Models.MeasureUnit>? Payload { get; set; }
}