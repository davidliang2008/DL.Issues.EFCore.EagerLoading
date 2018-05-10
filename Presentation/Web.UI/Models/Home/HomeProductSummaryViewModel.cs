using System;

namespace Web.UI.Models.Home
{
    public class HomeProductSummaryViewModel
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public int ImageCount { get; set; }
        public int SpecCount { get; set; }
    }
}
