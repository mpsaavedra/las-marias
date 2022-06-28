namespace LasMarias.WareHouse.Domain.EntityTypeConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LasMarias.WareHouse.Domain.Models;

public class MeasureUnitEntityTypeConfiguration : IEntityTypeConfiguration<MeasureUnit>
{
    public void Configure(EntityTypeBuilder<MeasureUnit> builder)
    {
        builder.HasKey(x => x.MeasureUnitId);
        builder
            .HasMany(x => x.Products)
            .WithOne(x => x.MeasureUnit);
    }
}