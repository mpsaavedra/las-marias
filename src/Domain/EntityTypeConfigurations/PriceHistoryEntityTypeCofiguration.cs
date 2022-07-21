namespace LasMarias.Domain.EntityTypeConfigurations;


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