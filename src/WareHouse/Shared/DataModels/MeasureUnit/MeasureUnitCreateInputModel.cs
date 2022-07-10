namespace LasMarias.WareHouse.Domain.DataModels.MeasureUnit;

using HotChocolate;
using LasMarias.WareHouse.Domain.Models;

public class MeasureUnitCreateInputModel 
{
    public string Name { get; set; }

    public Optional<string> Code { get; set; }

    public Optional<Cast> Cast { get; set; }

    public Optional<bool> Enable { get; set; }
}