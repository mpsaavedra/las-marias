namespace LasMarias.PoS.Domain.EntityTypeConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LasMarias.PoS.Domain.Models;

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
            .WithMany( x => x.Categories);
    }
}