using Day4WebApiWithDataDemo.Data;
using Day4WebApiWithDataDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day4WebApiWithDataDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        //Employee emp;
        private readonly AppDbContext _db;

        public EmployeesController(AppDbContext db)
        {
            //emp = new Employee() { };
            this._db = db;
        }

        //CRUD Operators 
        [HttpGet]
        public IActionResult EmployeeGet()
        {
            return Ok(_db.Employees.ToList());
        }
        //  /3
        [HttpGet("{id}")]
        public IActionResult EmployeeGet(int id)
        {
            var employee = _db.Employees.Find(id);
            if (employee == null)
                return NotFound();
            else
                return Ok(employee);
        }

        [HttpPost]
        public IActionResult Create(Employee newEmployee)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Add(newEmployee);
                _db.SaveChanges();
                return Created();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, Employee newEmployee)
        {
            if (id != newEmployee.EmployeeId)
            {
                return BadRequest("Id Not Match ....");
            }
            var employee = _db.Employees.Find(id);

            if (employee == null)
                return NotFound();

            employee.Name = newEmployee.Name;
            employee.JobTitle = newEmployee.JobTitle;
            employee.Salary = newEmployee.Salary;
            employee.Email = newEmployee.Email;
            employee.Mobile = newEmployee.Mobile;

            try
            {
                _db.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _db.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var employee = _db.Employees.Find(id);
            if (employee == null)
                return NotFound();

            _db.Employees.Remove(employee);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
