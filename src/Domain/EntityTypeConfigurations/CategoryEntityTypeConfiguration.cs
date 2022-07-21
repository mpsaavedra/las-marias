namespace LasMarias.Domain.EntityTypeConfigurations;

public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.CategoryId);
        builder
            .HasOne(x => x.ParentCategory)
            .WithMany(x => x.ChildCategories)
            .HasForeignKey(x => x.ParentCategoryId);
        builder
            .HasMany(x => x.Products)
            .WithMany(x => x.Categories);
        builder
            .HasMany(x => x.PlateCategories)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId);
    }
}