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

        public double div(double number1, double number2)
        {
            return number1 / number2;
        }
    }
}
