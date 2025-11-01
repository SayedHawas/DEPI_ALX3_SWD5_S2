using Microsoft.AspNetCore.Mvc;

namespace Day4WebAPIDemos.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public static List<string> Names = new List<string> { "Ahmed", "Tamer", "Yasser", "Mariem" };

        //https://localhost:7299/api/Employees 
        [HttpGet]
        public List<string> Get()
        {
            return Names.ToList();
        }
        //https://localhost:7299/api/Employees/2
        [HttpGet("{id}")]
        public string GetById(int id)
        {
            if (id > Names.Count)
            {
                return "Not Found";
            }
            else
                return Names[id];
        }



    }
}
