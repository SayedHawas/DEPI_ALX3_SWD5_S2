using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day8MVCDemo.Controllers
{
    public class ReadWirteController : Controller
    {
        // GET: ReadWirteController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ReadWirteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReadWirteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReadWirteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReadWirteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReadWirteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReadWirteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReadWirteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
