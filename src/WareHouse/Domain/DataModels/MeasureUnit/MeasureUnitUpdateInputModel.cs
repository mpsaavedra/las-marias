namespace LasMarias.WareHouse.Domain.DataModels.MeasureUnit;

using HotChocolate;
using LasMarias.WareHouse.Domain.Models;

public class MeasureUnitUpdateInputModel
{
    public long Id { get; set; }
    
    public Optional<string> Name { get; set; }

    public Optional<string> Code { get; set; }

    public Optional<Cast> Cast { get; set; }
}