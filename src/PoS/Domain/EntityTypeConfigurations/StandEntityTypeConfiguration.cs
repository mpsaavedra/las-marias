namespace LasMarias.PoS.Domain.EntityTypeConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LasMarias.PoS.Domain.Models;

public class StandEntityTypeConfiguration : IEntityTypeConfiguration<Stand>
{
    public void Configure(EntityTypeBuilder<Stand> builder)
    {
        builder.HasKey(x => x.StandId);
        builder
            .HasMany(x => x.Tables)
            .WithOne(x => x.Stand);
        builder
            .HasMany(x => x.Seats)
            .WithOne(x => x.Stand);
    }
}