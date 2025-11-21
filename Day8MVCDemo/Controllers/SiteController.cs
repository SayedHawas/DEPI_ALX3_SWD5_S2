using Microsoft.AspNetCore.Mvc;

namespace Day8MVCDemo.Controllers
{
    public class SiteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
