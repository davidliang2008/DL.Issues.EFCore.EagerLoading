using System;

namespace Data.EFCore.Entities
{
    public class ProductImageEntity
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public bool IsThumbnail { get; set; }
        public int Ordinal { get; set; }

        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; }
    }
}
