using Data.EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EFCore.Configurations
{
    public class ProductSpecificationConfiguration : IEntityTypeConfiguration<ProductSpecificationEntity>
    {
        public void Configure(EntityTypeBuilder<ProductSpecificationEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.Value).IsRequired();
            builder.HasIndex(x => new { x.ProductId, x.Value }).IsUnique();
            builder.Property(x => x.Price).IsRequired();

            builder.HasOne(x => x.Product)
                .WithMany(p => p.ProductSpecifications)
                .HasForeignKey(x => x.ProductId);

            builder.ToTable("ProductSpecification");
        }
    }
}
