namespace LasMarias.WareHouse.Domain.EntityTypeConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LasMarias.WareHouse.Domain.Models;

public class MovementEntityTypeConfiguration : IEntityTypeConfiguration<Movement>
{
    public void Configure(EntityTypeBuilder<Movement> builder)
    {
        builder.HasKey(x => x.MovementId);
        builder
            .HasOne(x => x.Vendor)
            .WithMany(x => x.Movements)
            .HasForeignKey( x => x.VendorId);
        builder
            .HasMany(x => x.ProductMovements)
            .WithOne(x => x.Movement);
    }    
}