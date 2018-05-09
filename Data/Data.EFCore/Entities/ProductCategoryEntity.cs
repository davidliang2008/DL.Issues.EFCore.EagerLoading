using Domain.ProductCategories;
using System;
using System.Collections.Generic;

namespace Data.EFCore.Entities
{
    public class ProductCategoryEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public ProductCategoryStatus Status { get; set; }

        public Guid ProductTypeId { get; set; }
        public ProductTypeEntity ProductType { get; set; }

        public List<ProductEntity> Products { get; set; }
    }
}
