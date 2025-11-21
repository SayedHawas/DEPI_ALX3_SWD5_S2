using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day8MVCDemo.Controllers
{
    public class CategoriesController : Controller
    {
        //DI DbContext
        private readonly AppDbContext _db;
        public CategoriesController(AppDbContext db)
        {
            this._db = db;
        }
        //CRUD 
        //Read All
        public async Task<ActionResult<IEnumerable<Category>>> Index()
        {
            //ViewData , ViewBag , Model
            //get List Of Categories
            //Call API
            var result = await _db.Categories.ToListAsync();
            return View(result);
        }
        //Create Open Form 
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category newCategory) //Model Binding 
        {
            //Save
            if (!ModelState.IsValid) //Validation
            {
                return View(newCategory);
            }
            _db.Categories.Add(newCategory);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public async Task<ActionResult<Category>> Details(int id)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
            return View(category);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = _db.Categories.Find(id);
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Category newCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(newCategory);
            }
            _db.Entry(newCategory).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var category = _db.Categories.Find(id);
            return View(category);
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var category = _db.Categories.Find(id);
            _db.Categories.Remove(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
