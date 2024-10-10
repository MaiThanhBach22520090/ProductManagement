using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ProductManagementContext _context;

        public CatalogController(ProductManagementContext context)
        {
            _context = context;
        }

        // GET: Catalog/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Catalog/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CatalogCode,CatalogName")] Catalog catalog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catalog);
                await _context.SaveChangesAsync();

                // Set a success message in TempData
                TempData["SuccessMessage"] = "Danh mục đã được tạo thành công!";
                return RedirectToAction(nameof(Index));  // Redirect to the Index action
            }
            return View(catalog);  // Return to the view if model state is not valid
        }

        // GET: Catalog/Index
        public async Task<IActionResult> Index()
        {
            return View(await _context.Catalogs.ToListAsync());
        }
    }
}
