using Data.EFCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Web.UI.Models.Home;

namespace Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var latestProductIds = _dbContext.DomainEvents
                .AsNoTracking()
                .Where(x => x.EventType == "Domain.Products.Events.ProductCreated")
                .OrderByDescending(x => x.TimeStamp)
                .Select(x => x.EntityId)
                .Distinct();

            var latestProducts = _dbContext.Products
                .AsNoTracking()
                .Include(x => x.ProductCategory)
                    .ThenInclude(x => x.ProductType)
                .Include(x => x.ProductImages)
                .Include(x => x.ProductSpecifications)
                .Where(x => x.Status == Domain.Products.ProductStatus.Published &&
                    latestProductIds.Contains(x.Id))
                .Take(8);

            var vm = new HomeViewModel
            {
                LatestProductIds = latestProductIds,
                LatestProducts = latestProducts.Select(x => new HomeProductSummaryViewModel
                {
                    ProductId = x.Id,
                    Name = x.Name,
                    Category = x.ProductCategory.Name,
                    Type = x.ProductCategory.ProductType.Name,
                    ImageCount = x.ProductImages.Count,
                    SpecCount = x.ProductSpecifications.Count
                })
            };
            return View(vm);
        }
    }
}