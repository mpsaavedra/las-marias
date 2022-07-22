namespace LasMarias.Domain.DataModels.MeasureUnit;

[GraphQLDescription("basic data to update a measure unit")]
public class MeasureUnitUpdateInputModel
{
    [GraphQLDescription("name of the measure unit")]
    public Optional<string> Name { get; set; }

    [GraphQLDescription("code of the measure unit")]
    public Optional<string> Code { get; set; }

    [GraphQLDescription("cast method to cast attribute value")]
    public Optional<Cast> Cast { get; set; }

    public Optional<bool> Enable { get; set; }
}