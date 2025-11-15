using Day8MVCDemo.Data;
using Day8MVCDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day8MVCDemo.Controllers
{
    public class CategoriesController : Controller
    {
        //DI DbConetxt
        private readonly AppDbContext _db;
        public CategoriesController(AppDbContext db)
        {
            this._db = db;
        }
        //CRUD 
        //Read All
        public IActionResult Index()
        {
            //ViewData , ViewBag , Model
            //get List Of Categories
            var result = _db.Categories.ToList();
            return View(result);
        }

        //Create Open Form 
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category newCategory)
        {
            //Save
            if (!ModelState.IsValid)
            {
                return View(newCategory);
            }
            _db.Categories.Add(newCategory);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
