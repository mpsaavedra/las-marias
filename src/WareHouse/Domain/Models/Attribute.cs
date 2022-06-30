namespace LasMarias.WareHouse.Domain.Models;

using System.Text.Json.Serialization;
using System.Collections.Generic;
using HotChocolate.Data;
using Orun.Domain;

public partial class Attribute : BusinessEntity<long>
{
    public Attribute()
    {
        Products = new HashSet<Product>();
    }

    public long AttributeId { get; set; }

    /// <summary>
    /// Value of the attribute
    /// </summary>
    public string Value { get; set; }

    /// <summary>
    /// a simple description in case the attribute is meanningful of something 
    /// bigger
    /// </summary>
    public string? Description { get; set; }

    public bool Enable { get; set; }

    public long MeasureUnitId { get; set; }

    public virtual MeasureUnit? MeasureUnit { get; set; }

    public long AttributeNameId { get; set; }

    public virtual AttributeName? AttributeName { get; set; }

    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<Product> Products { get; set; }

    #region Value casting operations

    /// <summary>
    /// This proprety will return the value parsed as a value if the type the measure
    /// unit claims to be formated to:
    /// example: if the measure unit claims for an integer number, this value returns a
    /// number
    /// <summary>
    public dynamic Amount
    {
        get
        {
            var ok = false;
            switch (MeasureUnit.Cast)
            {
                case Cast.ToDouble:
                    ok = double.TryParse(Value, out var resultDouble);
                    if(ok)
                        return resultDouble;
                    throw new Exception("Value could not be cast to Double");
                case Cast.ToInteger:
                    ok = int.TryParse(Value, out var resultInt);
                    if(ok)
                        return resultInt;
                    throw new Exception("Value could not be cast to Integer");
                case Cast.ToDecimal:
                    ok = decimal.TryParse(Value, out var result);
                    if(ok)
                        return result;
                    throw new Exception("Value could not be cast to Decimal");
                case Cast.ToString:
                    return Value; 
                default:
                    return Value;
            }
        }
    }

    #endregion
}