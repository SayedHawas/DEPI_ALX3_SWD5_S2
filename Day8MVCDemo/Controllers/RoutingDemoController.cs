using Microsoft.AspNetCore.Mvc;

namespace Day8MVCDemo.Controllers
{
    public class RoutingDemoController : Controller
    {
        public IActionResult Index(int id, string name, string address)
        {
            return Content($"id {id} name {name}  Address {address}");

        }


        //[Route("route/{name:alpha}")]
        //[HttpGet]

        [HttpGet("route/{name:alpha}")]
        public IActionResult RouteCustom(string name)
        {
            return Content(name);
        }

    }
}
