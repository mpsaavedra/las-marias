namespace LasMarias.WareHouse.Domain.EntityTypeConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LasMarias.WareHouse.Domain.Models;

public class ProductMovementEntityTypeConfiguration : IEntityTypeConfiguration<ProductMovement>
{
    public void Configure(EntityTypeBuilder<ProductMovement> builder)
    {
        builder.HasKey(x => x.ProductMovementId);        
        builder
            .HasOne(x => x.Product)
            .WithMany(x => x.ProductMovements)
            .HasForeignKey(x => x.ProductId);
        builder
            .HasOne(x => x.Movement)
            .WithMany(x => x.ProductMovements)
            .HasForeignKey(x => x.MovementId);
        builder
            .HasOne(x => x.Vouce)
            .WithMany(x => x.ProductMovements)
            .HasForeignKey(x => x.VouceId);
    }
}