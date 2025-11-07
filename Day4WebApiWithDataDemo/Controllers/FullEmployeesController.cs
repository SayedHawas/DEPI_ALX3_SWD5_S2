using Day4WebApiWithDataDemo.DTOs.EmployeeDto;

namespace Day4WebApiWithDataDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FullEmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FullEmployeesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/FullEmployees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeGetDto>>> GetEmployees()
        {
            var employeeList = await _context.Employees.Include("Department").ToListAsync();
            if (employeeList == null) return NotFound();
            List<EmployeeGetDto> result = new List<EmployeeGetDto>();
            foreach (var item in employeeList)
            {
                result.Add(new EmployeeGetDto
                {
                    EmployeeId = item.EmployeeId,
                    Name = item.Name,
                    JobTitle = item.JobTitle,
                    Salary = item.Salary,
                    Email = item.Email,
                    Mobile = item.Mobile,
                    departmentName = item.Department.Name
                });
            }
            return Ok(result);
        }
        // GET: api/FullEmployees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeGetDto>> GetEmployee(int id)
        {
            //var employee = await _context.Employees.FindAsync(id);
            var employee = await _context.Employees.Include("Department").FirstOrDefaultAsync(e => e.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }
            var result = new EmployeeGetDto
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                JobTitle = employee.JobTitle,
                Salary = employee.Salary,
                Email = employee.Email,
                Mobile = employee.Mobile,
                departmentName = employee.Department.Name
            };
            return Ok(result);
        }

        // PUT: api/FullEmployees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, EmployeePutDto employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid) return BadRequest(employee);
            Employee empSelect = await _context.Employees.FindAsync(id);
            if (empSelect == null) return NotFound();

            empSelect.Name = employee.Name;
            empSelect.JobTitle = employee.JobTitle;
            empSelect.Salary = employee.Salary;
            empSelect.Email = employee.Email;
            empSelect.Mobile = employee.Mobile;
            empSelect.departmentId = employee.departmentId;


            //_context.Entry(employee).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }

            return NoContent();
        }

        // POST: api/FullEmployees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(EmployeePostDto employee)
        {
            if (!ModelState.IsValid) return BadRequest(employee);
            Employee newEmployee = new Employee()
            {
                Name = employee.Name,
                JobTitle = employee.JobTitle,
                Salary = employee.Salary,
                Email = employee.Email,
                Mobile = employee.Mobile,
                departmentId = employee.departmentId
            };
            ; _context.Employees.Add(newEmployee);
            await _context.SaveChangesAsync();
            int newId = _context.Employees.Max(e => e.EmployeeId);
            return CreatedAtAction("GetEmployee", new { id = newId }, employee);
        }

        // DELETE: api/FullEmployees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
        [HttpGet("Pagination")]
        public async Task<ActionResult<IEnumerable<EmployeeGetDto>>> GetWithPagination([FromQuery] int page = 1, [FromQuery] int pageSize = 5)
        {
            var Employees = await _context.Employees.Include("Department").ToListAsync();
            List<EmployeeGetDto> result = new List<EmployeeGetDto>();
            foreach (var item in Employees)
            {
                result.Add(new EmployeeGetDto()
                {
                    EmployeeId = item.EmployeeId,
                    Name = item.Name,
                    JobTitle = item.JobTitle,
                    Salary = item.Salary,
                    Email = item.Email,
                    Mobile = item.Mobile,
                    departmentName = item.Department.Name
                });
            }
            //Pagination
            var totalCount = Employees.Count();
            var totalPage = (int)Math.Ceiling((double)totalCount / pageSize);
            result = result.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return Ok(result);
        }

    }
}
