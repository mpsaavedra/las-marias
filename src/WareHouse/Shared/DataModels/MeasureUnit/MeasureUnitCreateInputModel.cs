namespace LasMarias.WareHouse.Domain.DataModels.MeasureUnit;

using HotChocolate;
using LasMarias.WareHouse.Domain.Models;

[GraphQLDescription("basic data to create a new Measure unit")]
public class MeasureUnitCreateInputModel 
{
    [GraphQLDescription("name")]
    public string Name { get; set; }

    [GraphQLDescription("code")]
    public Optional<string> Code { get; set; }

    [GraphQLDescription("which cast method to use when casting the attribute value")]
    public Optional<Cast> Cast { get; set; }

    [GraphQLDescription("if true is available to the system")]
    public Optional<bool> Enable { get; set; }
}