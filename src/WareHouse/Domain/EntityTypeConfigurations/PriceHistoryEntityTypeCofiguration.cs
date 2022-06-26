namespace LasMarias.WareHouse.Domain.EntityTypeConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LasMarias.WareHouse.Domain.Models;

public class PriceHistoryEntityTypeConfiguration : IEntityTypeConfiguration<PriceHistory>
{
    public void Configure(EntityTypeBuilder<PriceHistory> builder)
    {
        builder.HasKey(x => x.PriceHistoryId);
        builder
            .HasOne(x => x.Product)
            .WithMany(x => x.PriceHistories)
            .HasForeignKey(x => x.PriceHistoryId);
        
    }
}