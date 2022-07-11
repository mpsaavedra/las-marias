

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LasMarias.WareHouse.Domain.Models;

namespace LasMarias.WareHouse.Domain.EntityTypeConfigurations;

public class VouceEntityTypeConfiguration : IEntityTypeConfiguration<Vouce>
{
    public void Configure(EntityTypeBuilder<Vouce> builder)
    {
        builder.HasKey(x => x.VouceId);
        builder
            .HasMany(x => x.ProductMovements)
            .WithOne(x => x.Vouce)
            .HasForeignKey(x => x.VouceId);
    }    
}