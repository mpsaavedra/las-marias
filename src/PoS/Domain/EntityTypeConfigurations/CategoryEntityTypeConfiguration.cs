namespace LasMarias.PoS.Domain.EntityTypeConfigurations;

using LasMarias.PoS.Domain.Models;

public class CategoryEntityTypeCofiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.CategoryId);
        builder
            .HasOne(x => x.ParentCategory)
            .WithMany(x => x!.ChildCategories)
            .HasForeignKey(x => x.ParentCategoryId);
        builder
            .HasMany(x => x.PlateCategories)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId);
    }
}