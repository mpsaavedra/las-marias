namespace LasMarias.PoS.Domain.EntityTypeConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LasMarias.PoS.Domain.Models;

public class TableEntityTypeConfiguration : IEntityTypeConfiguration<Table>
{
    public void Configure(EntityTypeBuilder<Table> builder)
    {
        builder.HasKey(x => x.TableId);
        builder
            .HasOne(x => x.Stand)
            .WithMany(x => x.Tables)
            .HasForeignKey(x => x.TableId);
        builder
            .HasMany(x => x.Seats)
            .WithOne(x => x.Table);
    }
}