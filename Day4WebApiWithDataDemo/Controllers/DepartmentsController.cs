// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Day4WebApiWithDataDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public DepartmentsController(AppDbContext db)
        {
            this._db = db;
        }
        //[HttpGet]
        //public IEnumerable<Department> DepartmentGet()
        //{
        //    return _db.Departments.Include("Employees").ToList();
        //}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentGetDto>>> DepartmentGet()
        {
            var source = await _db.Departments.AsNoTracking().Include("Employees").ToListAsync();

            if (source == null) return NotFound();

            List<DepartmentGetDto> result = new List<DepartmentGetDto>();

            foreach (var department in source)
            {
                result.Add(new DepartmentGetDto()
                {
                    DepartmentId = department.DepartmentId,
                    Name = department.Name,
                    Description = department.Description,
                    EmployeeCount = department.Employees.Count,
                    EmployeesName = department.Employees.Select(e => e.Name).ToList()
                });
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentGetDto>> DepartmentByIdGet(int id)
        {
            //var department = await _db.Departments.FindAsync(id);
            var department = await _db.Departments.Include("Employees").FirstOrDefaultAsync(e => e.DepartmentId == id);
            if (department == null) return NotFound();
            //fill with DTO
            DepartmentGetDto result = new DepartmentGetDto()
            {
                DepartmentId = department.DepartmentId,
                Name = department.Name,
                Description = department.Description,
                EmployeeCount = department.Employees.Count,
                EmployeesName = department.Employees.Select(e => e.Name).ToList()
            };
            return Ok(result);
        }
        //deSerialization Json 
        [HttpPost]                                //Model Binding
        public async Task<IActionResult> Post([FromBody] DepartmentPostDto newDepartment)
        {
            if (newDepartment == null) return BadRequest();
            //Model State Object dataAnnotation Validation
            if (!ModelState.IsValid)
            {
                return BadRequest(newDepartment);
            }
            try
            {
                _db.Departments.Add(new Department()
                {
                    Name = newDepartment.Name,
                    Description = newDepartment.Description
                });
                await _db.SaveChangesAsync();
                //return Created(); //201
                //Location
                //return CreatedAtAction("DepartmentByIdGet", new { id = newDepartment.DepartmentId },newDepartment);
                //Get ID After Insert 
                int newId = _db.Departments.Max(i => i.DepartmentId);
                // https://localhost:7029/api/Departments/4
                return CreatedAtAction("DepartmentByIdGet", new { id = newId }, newDepartment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DepartmentPutDto updateDepartment)
        {
            if (id != updateDepartment.DepartmentId) return BadRequest("Id Not Match...");

            if (!ModelState.IsValid)
            {
                return BadRequest(updateDepartment);
            }
            try
            {
                var department = await _db.Departments.FindAsync(id);
                department.Name = updateDepartment.Name;
                department.Description = updateDepartment.Description;
                await _db.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var department = await _db.Departments.FindAsync(id);
            if (department == null) return NotFound();
            _db.Departments.Remove(department);
            await _db.SaveChangesAsync();
            return NoContent();
        }
        [HttpGet("Pagination")]
        public async Task<ActionResult<IEnumerable<DepartmentGetDto>>> GetWithPagination([FromQuery] int page = 1, [FromQuery] int pageSize = 5)
        {
            var departments = await _db.Departments.ToListAsync();
            List<DepartmentGetDto> result = new List<DepartmentGetDto>();
            foreach (var item in departments)
            {
                result.Add(new DepartmentGetDto()
                {
                    DepartmentId = item.DepartmentId,
                    Name = item.Name,
                    Description = item.Description,
                    EmployeeCount = item.Employees.Count,
                    EmployeesName = item.Employees.Select(e => e.Name).ToList()
                });
            }
            //Pagination
            var totalCount = departments.Count();
            var totalPage = (int)Math.Ceiling((double)totalCount / pageSize);
            result = result.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return Ok(result);
        }
    }
}
