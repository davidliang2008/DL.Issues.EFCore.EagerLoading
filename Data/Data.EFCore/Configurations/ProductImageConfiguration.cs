using Data.EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EFCore.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImageEntity>
    {
        public void Configure(EntityTypeBuilder<ProductImageEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.Url).IsRequired();
            builder.Property(x => x.Ordinal).IsRequired();

            builder.HasOne(x => x.Product)
                .WithMany(p => p.ProductImages)
                .HasForeignKey(x => x.ProductId);

            builder.ToTable("ProductImage");
        }
    }
}
