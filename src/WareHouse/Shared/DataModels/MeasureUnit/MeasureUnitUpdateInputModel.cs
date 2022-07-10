namespace LasMarias.WareHouse.Domain.DataModels.MeasureUnit;

using HotChocolate;
using LasMarias.WareHouse.Domain.Models;

[GraphQLDescription("basic data to update a measure unit")]
public class MeasureUnitUpdateInputModel
{
    [GraphQLDescription("id of the measure unit to update")]
    public long Id { get; set; }
    
    [GraphQLDescription("name of the measure unit")]
    public Optional<string> Name { get; set; }

    [GraphQLDescription("code of the measure unit")]
    public Optional<string> Code { get; set; }

    [GraphQLDescription("cast method to cast attribute value")]
    public Optional<Cast> Cast { get; set; }
}