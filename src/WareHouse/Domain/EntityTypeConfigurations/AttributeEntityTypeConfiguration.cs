namespace LasMarias.WareHouse.Domain.EntityTypeConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LasMarias.WareHouse.Domain.Models;

public class AttributeEntityTypeConfiguration : IEntityTypeConfiguration<Attribute>
{
    public void Configure(EntityTypeBuilder<Attribute> builder)
    {
        builder.HasKey(x => x.AttributeId);

        builder
            .HasOne(x => x.AttributeName)
            .WithMany(x => x.Attributes);

        builder
            .HasMany(x => x.Products)
            .WithMany(x => x.Attributes);
    }    
}