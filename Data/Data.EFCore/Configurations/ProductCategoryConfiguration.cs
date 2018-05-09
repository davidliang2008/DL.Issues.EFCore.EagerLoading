using Data.EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EFCore.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<ProductCategoryEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProductTypeId).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Slug).IsRequired();
            builder.HasIndex(x => x.Slug).IsUnique();

            builder.HasOne(x => x.ProductType)
                .WithMany(t => t.ProductCategories)
                .HasForeignKey(x => x.ProductTypeId);

            builder.ToTable("ProductCategory");
        }
    }
}
