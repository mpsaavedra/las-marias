namespace LasMarias.Domain.EntityTypeConfigurations;

public class TableEntityTypeConfiguration : IEntityTypeConfiguration<Table>
{
    public void Configure(EntityTypeBuilder<Table> builder)
    {
        builder.HasKey(x => x.TableId);
        builder
            .HasOne(x => x.Stand)
            .WithMany(x => x!.Tables);
        builder
            .HasMany(x => x.Seats)
            .WithOne(x => x.Table!);
    }
}