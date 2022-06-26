namespace LasMarias.PoS.Domain.EntityTypeConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LasMarias.PoS.Domain.Models;

public class AttributeNameEntityTypeConfiguration : IEntityTypeConfiguration<AttributeName>
{
    public void Configure(EntityTypeBuilder<AttributeName> builder)
    {
        builder.HasKey(x => x.AttributeNameId);
        
        builder
            .HasMany(x => x.Attributes)
            .WithOne(x => x.AttributeName)
            .HasForeignKey(x => x.AttributeNameId);

        builder
            .Property(x => x.Name)
            .HasMaxLength(250)
            .IsRequired();

        builder
            .HasIndex(x => x.Name);
    }
}