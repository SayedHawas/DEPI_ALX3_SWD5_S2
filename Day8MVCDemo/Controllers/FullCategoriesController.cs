using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day8MVCDemo.Controllers
{
    public class FullCategoriesController : Controller
    {
        //private readonly AppDbContext _context;
        //public FullCategoriesController(AppDbContext context)
        //{
        //    _context = context;
        //}

        private readonly IServiceCategory _context;
        public FullCategoriesController(IServiceCategory context)
        {
            this._context = context;
        }
        // GET: FullCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetCategoriesAsync());
        }
        // GET: FullCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = await _context.GetCategoryByIDAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        // GET: FullCategories/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: FullCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(category);
                //await _context.SaveChangesAsync();
                _context.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        // GET: FullCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //var category = await _context.Categories.FindAsync(id);
            var category = await _context.GetCategoryByIDAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        // POST: FullCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(category);
                    //await _context.SaveChangesAsync();
                    _context.UpdateCategory(category);
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!CategoryExists(category.CategoryId))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        // GET: FullCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //var category = await _context.Categories.FirstOrDefaultAsync(m => m.CategoryId == id);
            var category = await _context.GetCategoryByIDAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        // POST: FullCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var category = await _context.Categories.FindAsync(id);
            var category = await _context.GetCategoryByIDAsync(id);
            if (category != null)
            {
                _context.DeleteCategory(id);
            }
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //private bool CategoryExists(int id)
        //{
        //    return _context.Categories.Any(e => e.CategoryId == id);
        //}
        public async Task<IEnumerable<Category>> GetWithPagnation(int page = 1, int pageSize = 6)
        {
            return await _context.PaginationCategoryAsync(page, pageSize);
        }
    }
}
