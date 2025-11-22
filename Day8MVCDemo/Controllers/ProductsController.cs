using Day8MVCDemo.CustomBinding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Day8MVCDemo.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;
        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            //var appDbContext = _context.Products.Include(p => p.Category);
            //return View(await appDbContext.ToListAsync());


            var listProduct = await _context.Products.Include(p => p.Category).ToListAsync();
            List<Product> products = new List<Product>();
            foreach (var item in listProduct)
            {
                if (System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/products", item.PhotoPath)))
                {
                    products.Add(item);
                }
                else
                {
                    item.PhotoPath = "";
                    products.Add(item);
                }
            }
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            #region OldCode
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var product = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(m => m.ProductId == id);
            //if (product == null)
            //{
            //    return NotFound();
            //}

            //return View(product); 
            #endregion
            if (id == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            if (!System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/products", product.PhotoPath)))
            {
                product.PhotoPath = "";
            }
            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["categoryId"] = new SelectList(_context.Categories, "CategoryId", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([ModelBinder(typeof(ProductModelBind))] Product product, IFormFile PhotoPath)
        {
            if (PhotoPath != null && PhotoPath.Length > 0)
            {
                //~
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/products", PhotoPath.FileName);
                //Stream File As Byte Array
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await PhotoPath.CopyToAsync(stream);
                }
                product.PhotoPath = PhotoPath.FileName;
            }
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["categoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", product.categoryId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["categoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", product.categoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["categoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", product.categoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
