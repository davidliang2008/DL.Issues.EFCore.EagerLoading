using System;
using System.Collections.Generic;

namespace Web.UI.Models.Home
{
    public class HomeViewModel
    {
        public IEnumerable<Guid> LatestProductIds { get; set; }
        public IEnumerable<HomeProductSummaryViewModel> LatestProducts { get; set; }
    }
}
