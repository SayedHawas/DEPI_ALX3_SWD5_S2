using Day8MVCDemo.CustomBinding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Day8MVCDemo.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;
        [TempData]
        public string MessageAdd { get; set; }
        [TempData]
        public string MessageDelete { get; set; }
        public ProductsController(AppDbContext context)
        {
            _context = context;
        }
        // GET: Products
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //var appDbContext = _context.Products.Include(p => p.Category);
            //return View(await appDbContext.ToListAsync());

            var listProduct = await _context.Products.AsNoTracking().Include(p => p.Category).ToListAsync();
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
            var product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(m => m.ProductId == id);
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
            if (!ModelState.IsValid)
            {
                ViewData["categoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", product.categoryId);
                return View(product);
            }

            if (PhotoPath != null && PhotoPath.Length > 0)
            {
                //RenName
                //ii.png
                string _Extenstion = Path.GetExtension(PhotoPath.FileName); //.png
                string _fileName = DateTime.Now.ToString("yyMMddhhmmssfff") + _Extenstion;
                product.PhotoPath = _fileName;

                //~
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/products", _fileName);
                //Stream File As Byte Array
                //using (var stream = new FileStream(filePath, FileMode.Create))
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await PhotoPath.CopyToAsync(stream);
                }
                //product.PhotoPath = PhotoPath.FileName;
            }

            _context.Add(product);
            await _context.SaveChangesAsync();
            //Add Message As TempData
            MessageAdd = $"Product {product.Name} added";
            return RedirectToAction(nameof(Index));
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
        public async Task<IActionResult> Edit(int id, Product product, IFormFile PhotoPath)
        {
            if (PhotoPath != null && PhotoPath.Length > 0)
            {
                //RenName
                //ii.png
                string _Extenstion = Path.GetExtension(PhotoPath.FileName); //.png
                string _fileName = DateTime.Now.ToString("yyMMddhhmmssfff") + _Extenstion;
                product.PhotoPath = _fileName;

                //~
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/products", _fileName);
                //Stream File As Byte Array
                //using (var stream = new FileStream(filePath, FileMode.Create))
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await PhotoPath.CopyToAsync(stream);
                }
                //product.PhotoPath = PhotoPath.FileName;
            }
            //Remove Old Image  ??
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
            MessageDelete = $"Product {product.Name} successfully deleted!";
            //TempData["MessageDelete"] = $"Product {product.Name} successfully deleted!";
            //TempData.Keep("MessageDelete");
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }

        #region More Oprtaions
        [HttpGet]
        public async Task<IActionResult> Card(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            if (System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/products", product.PhotoPath)))
            {
                return View(product);
            }
            else
            {
                product.PhotoPath = "";
                return View(product);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Gallery()
        {
            return View(await _context.Products.AsNoTracking().ToListAsync());
        }
        public async Task<IActionResult> GalleryWithPagnation(int page = 1, int pageSize = 6)
        {
            var totalItems = await _context.Products.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            //var products = await _context.Products.AsNoTracking().ToListAsync();
            //var products = await _context.Products.Skip((page - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();

            // IEnumerable<Product>  Vs IQueryable<Product>
            //    In Memory                in SQL 

            var products = await _context.Products
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalItems = totalItems;

            return View(products);
        }
        #endregion


        public IActionResult CheckPrice(decimal Price)
        {
            if (Price > 1)
            {
                return Json(true);
            }
            return Json(false);
        }
    }
}

//var products = await _context.Products
//    .OrderBy(p => p.ProductId)
//    .Skip((page - 1) * pageSize)
//    .Take(pageSize)
//    .ToListAsync();
