namespace LasMarias.Domain.EntityTypeConfigurations;

public class MenuEntityTypeCofiguration : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.HasKey(x => x.MenuId);
        builder
            .HasMany(x => x.MenuPlates)
            .WithOne(x => x.Menu)
            .HasForeignKey(x => x.MenuId);
    }
}