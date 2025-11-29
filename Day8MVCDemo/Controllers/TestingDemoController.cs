using Microsoft.AspNetCore.Mvc;

namespace Day8MVCDemo.Controllers
{
    public class TestingDemoController : Controller
    {
        public IActionResult Index()
        {
            ViewData["TestText"] = "Welcome in MVC Unit Test ";
            return View();
        }
    }
}
