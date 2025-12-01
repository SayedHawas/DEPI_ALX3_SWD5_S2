using Microsoft.AspNetCore.Mvc;

namespace Day8MVCDemo.Controllers
{
    public class StateDemosController : Controller
    {
        public IActionResult Index()
        {
            var cookie = Request.Cookies["AppName"];
            ViewBag.MyCookie = cookie;
            return View();
        }
        public IActionResult SetTempData()
        {
            ViewData["Number"] = 200;
            TempData["AppName"] = "Smart software";
            return Content("Save Data into Temp Data ");
        }
        public IActionResult GetTempData()
        {
            //if (TempData.Keys.Contains("AppName"))
            //{ 

            //}
            string name = "Empty Name ";
            if (TempData.ContainsKey("AppName"))
            {
                //normal read
                name = TempData["AppName"].ToString();
            }
            return Content(" get Data " + name + " Please check cookies ...");
        }
        public IActionResult GetTempDataSecond()
        {
            string name = "Empty Name ";
            if (TempData.ContainsKey("AppName"))
            {
                //normal read
                name = TempData["AppName"].ToString();
            }
            return Content(" get Data " + name + " Please check cookies ...");
        }
        // Peek
        public IActionResult GetTempDataPeek()
        {
            string name = "Empty Name ";
            if (TempData.ContainsKey("AppName"))
            {
                name = TempData.Peek("AppName").ToString();

            }
            return Content(" get Data " + name + " Please check cookies ...");
        }
        //Keep After Normal Read
        public IActionResult GetTempDataKeep()
        {
            string name = "Empty Name ";
            if (TempData.ContainsKey("AppName"))
            {
                name = TempData["AppName"].ToString();
                //name = TempData.Peek("AppName").ToString();
                // TempData.Keep(); //For All Key
                TempData.Keep("AppName"); //On Key
            }

            return Content(" get Data " + name + " Please check cookies ...");
        }
        public IActionResult SetCookies()
        {
            Response.Cookies.Append("AppName", "Smart software");  //Session Cookies 20 Min
            Response.Cookies.Append("Number", "120");

            return Content("Cookies Saving ....");
        }
        public IActionResult GetCookies()
        {
            string appName = Request.Cookies["AppName"];
            int Number = int.Parse(Request.Cookies["Number"]);
            string company = Request.Cookies["CompanyName"];

            return Content($"Cookies:{appName} & {Number} & {company}");
        }
        public IActionResult SetCookiesPersistent()
        {

            CookieOptions cookieOptions = new CookieOptions();
            //cookieOptions.Expires = DateTimeOffset.Now.AddHours(3);
            cookieOptions.Expires = DateTimeOffset.Now.AddDays(15);
            Response.Cookies.Append("CompanyName", "Smart software", cookieOptions);

            return Content("Cookies Persistent Saving ....");
        }
        public IActionResult RemoveCookiesPersistent()
        {

            CookieOptions cookieOptions = new CookieOptions();
            //cookieOptions.Expires = DateTimeOffset.Now.AddHours(3);
            cookieOptions.Expires = DateTimeOffset.Now.AddDays(-1);
            Response.Cookies.Append("CompanyName", "Smart software", cookieOptions);

            return Content("Cookies Persistent Remove ....");
        }

        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("name", "Sayed");
            HttpContext.Session.SetInt32("Counter", 100);
            return Content("Save Session ");
        }
        public IActionResult GetSession()
        {
            string name = HttpContext.Session.GetString("name");
            int? counter = HttpContext.Session.GetInt32("Counter");
            return Content($"Name {name} & Counter {counter}  ");
        }

        public IActionResult ShowQuery()
        {
            return View();
        }
    }
}
