using Domain.Products;
using System;
using System.Collections.Generic;

namespace Data.EFCore.Entities
{
    public class ProductEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public ProductStatus Status { get; set; }

        public Guid ProductCategoryId { get; set; }
        public ProductCategoryEntity ProductCategory { get; set; }

        public List<ProductImageEntity> ProductImages { get; set; }
        public List<ProductSpecificationEntity> ProductSpecifications { get; set; }
    }
}
