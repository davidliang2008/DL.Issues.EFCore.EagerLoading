using System;

namespace Data.EFCore.Entities
{
    public class ProductSpecificationEntity
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public double Price { get; set; }
        public double? DiscountedPrice { get; set; }

        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; }
    }
}
