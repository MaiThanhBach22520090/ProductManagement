using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductManagementContext _context;

        public ProductController(ProductManagementContext context)
        {
            _context = context;
        }

        // GET: Product/Index
        public async Task<IActionResult> Index(int? catalogId, double? minPrice, double? maxPrice)
        {
            // Lấy tất cả các sản phẩm
            var productsQuery = _context.Products.Include(p => p.Catalog).AsQueryable();

            // Lọc theo Catalog nếu có
            if (catalogId.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.CatalogID == catalogId.Value);
            }

            // Lọc theo giá nếu có
            if (minPrice.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.UnitPrice >= minPrice.Value);
            }
            if (maxPrice.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.UnitPrice <= maxPrice.Value);
            }

            // Trả về ViewData các giá trị lọc hiện tại
            ViewData["CatalogID"] = new SelectList(_context.Catalogs, "Id", "CatalogName", catalogId);
            ViewData["CurrentCatalogId"] = catalogId;
            ViewData["CurrentMinPrice"] = minPrice;
            ViewData["CurrentMaxPrice"] = maxPrice;

            return View(await productsQuery.ToListAsync());
        }
    }
}
