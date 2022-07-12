namespace LasMarias.PoS.Domain.Models;

public class MenuPlateEntityTypeConfiguration: IEntityTypeConfiguration<MenuPlate>
{
    public void Configure(EntityTypeBuilder<MenuPlate> builder)
    {
        builder.HasKey(x => x.MenuPlateId);
        builder
            .HasOne(x => x.Plate)
            .WithMany(x => x.MenuPlates)
            .HasForeignKey(x => x.PlateId);
        builder
            .HasOne(x => x.Menu)
            .WithMany(x => x.MenuPlates)
            .HasForeignKey(x => x.MenuId);
    }    
}