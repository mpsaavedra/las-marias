namespace LasMarias.WareHouse.Domain.Models;

using System.Text.Json.Serialization;
using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Data;
using Orun.Domain;

[GraphQLDescription("attribute of the product")]
public partial class Attribute : BusinessEntity<long>
{
    public Attribute()
    {
        Products = new HashSet<Product>();
    }
    [GraphQLDescription("id of the attribute")]
    public long AttributeId { get; set; }

    /// <summary>
    /// Value of the attribute
    /// </summary>
    [GraphQLDescription("value of the attribute")]
    public string Value { get; set; }

    /// <summary>
    /// a simple description in case the attribute is meanningful of something 
    /// bigger
    /// </summary>
    [GraphQLDescription("description of the attribute")]
    public string? Description { get; set; }

    [GraphQLDescription("if true attribute is available in the system")]
    public bool Enable { get; set; }

    [GraphQLDescription("id of the measure unit")]
    public long? MeasureUnitId { get; set; }

    [GraphQLDescription("measure unit this attribute is measured")]
    public virtual MeasureUnit? MeasureUnit { get; set; }

    [GraphQLDescription("id of the attribute name")]
    public long AttributeNameId { get; set; }

    [GraphQLDescription("name of this attribute")]
    public virtual AttributeName? AttributeName { get; set; }

    [GraphQLDescription("list of produts that uses this attribute")]
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
    [GraphQLDescription("returns the casted value of the attribute, cast is made using the measute unit cast")]
    public dynamic Amount
    {
        get
        {
            if(MeasureUnit == null)
                return (string)Value;
                
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