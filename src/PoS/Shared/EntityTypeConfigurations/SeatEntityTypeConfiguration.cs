namespace LasMarias.PoS.Domain.EntityTypeConfigurations;


public class SeatEntityTypeConfiguration: IEntityTypeConfiguration<Seat>
{
    public void Configure(EntityTypeBuilder<Seat> builder)
    {
        builder.HasKey(x => x.SeatId);
        builder
            .HasOne(x => x.Table)
            .WithMany(x => x!.Seats)
            .HasForeignKey(x => x.TableId);
        builder
            .HasOne(x => x.Stand)
            .WithMany(x => x!.Seats)
            .HasForeignKey(x => x.StandId);
        builder
            .HasIndex(x => x.Code);
    }
}