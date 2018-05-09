using Domain.ProductTypes;
using System;
using System.Collections.Generic;

namespace Data.EFCore.Entities
{
    public class ProductTypeEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public ProductTypeStatus Status { get; set; }

        public List<ProductCategoryEntity> ProductCategories { get; set; }
    }
}
