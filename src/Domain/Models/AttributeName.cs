namespace LasMarias.Domain.Models;

/// <summary>
/// The attribute name class define the name of a given attribute providing the attribute
/// entity with a more flexible attributes set
/// </summary>
[GraphQLDescription("name of the attribute")]
public partial class AttributeName : BusinessEntity<long>
{
    public AttributeName()
    {
        Name = "";
        Attributes = new HashSet<Attribute>();
        Enable = true;
    }

    public AttributeName(string name)
    {
        Name = name;
        Attributes = new HashSet<Attribute>();
        Enable = true;
    }

    [GraphQLDescription("id of the attribute name")]
    public long AttributeNameId { get; set; }

    /// <summary>
    /// Name of the attribute name
    /// </summary>
    [GraphQLDescription("name of the attribute")]
    public string Name { get; set; }

    [GraphQLDescription("if true this attribute name is available to the system")]
    public bool Enable { get; set; }

    [GraphQLDescription("list of attributes that uses this name")]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<Attribute>? Attributes { get; set; }
}