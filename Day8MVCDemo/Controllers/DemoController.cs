using Microsoft.AspNetCore.Mvc;

namespace Day8MVCDemo.Controllers
{
    public class DemoController : Controller
    {

        public IActionResult Index()
        {
            ViewData["AppName"] = "Smart Application";
            ViewData["Num1"] = 10;
            ViewData.Add("Num2", 20);

            ViewBag.Number1 = 100;
            ViewBag.Number2 = 200;
            return View();
        }

        public string ShowName(string name)
        {
            return $" Welcome {name} ";
        }
        /*
           1- Content "String"   => ContentResult
            2- View "HTML"        => ViewResult
            3- Json               => JsonResult
            4- File               => FileResult
            5- Empty              => Emptyresult 
            6- PartialView        => PartialViewResult   (Later)
         */
        public IActionResult ShowContent()
        {
            var msg = new ContentResult();
            msg.Content = "Welcome in Content";
            return msg;
        }
        public IActionResult ShowView()
        {
            var view = new ViewResult();
            view.ViewName = "Views/Demo/MyView.cshtml";
            return view;

            //return View("");
        }
        public IActionResult ShowJson()
        {
            return Json(new { ID = 1, Name = "Osama", Salary = 20000 });
        }
        public IActionResult ShowFile()
        {
            return File("~/Smart Welcome in MVC.txt", "text/plain");
        }
        public IActionResult ShowEmpty()
        {
            return new EmptyResult(); //or return null;
        }
        //Localhost:7013/demo/ShowMsWithPara/5
        public string ShowMsgWithPara(int id)
        {
            return $"Welcome Message With Id {id}";
        }
        //Localhost:7013/demo/ShowMsWithPara?name=ahmed
        public string ShowMSgWithParaNotID(string Name)
        {
            return $"Welcome Message {Name} Name ";
        }
        public IActionResult RedirectToShowContent()
        {
            //Logical Code 
            return RedirectToAction("ShowContent");
        }
    }
}
