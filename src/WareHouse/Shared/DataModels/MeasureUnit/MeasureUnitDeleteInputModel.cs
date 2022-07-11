namespace LasMarias.WareHouse.Domain.DataModels.MeasureUnit;

using HotChocolate;

[GraphQLDescription("basic data to delete a measure unit")]
public class MeasureUnitDeleteInputModel
{
    [GraphQLDescription("id of the measure unit to delete")]
    public long Id { get; set; }
}