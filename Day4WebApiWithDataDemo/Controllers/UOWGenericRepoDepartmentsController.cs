namespace Day4WebApiWithDataDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UOWGenericRepoDepartmentsController : ControllerBase
    {
        private readonly IServiceDepartment _service;

        public UOWGenericRepoDepartmentsController(IServiceDepartment service)
        {
            _service = service;
        }
        // GET: api/UOWGenericRepoDepartments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentGetDto>>> GetDepartments()
        {
            return Ok(_service.GetDepartments().ToList());
        }
        // GET: api/UOWGenericRepoDepartments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentGetDto>> GetDepartment(int id)
        {
            var department = _service.GetDepartmentByIDWithIncluding(id, "Employees");  //await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }
        // PUT: api/UOWGenericRepoDepartments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, DepartmentPutDto department)
        {
            if (id != department.DepartmentId)
            {
                return BadRequest();
            }
            _service.UpdateDepartment(department);
            return NoContent();
        }
        // POST: api/UOWGenericRepoDepartments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DepartmentPostDto>> PostDepartment(DepartmentPostDto department)
        {
            //_context.Departments.Add(department);
            //await _context.SaveChangesAsync();
            if (!ModelState.IsValid) return BadRequest();
            _service.AddDepartment(department);
            return CreatedAtAction("GetDepartment", new { id = department.DepartmentId }, department);
        }
        // DELETE: api/UOWGenericRepoDepartments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = _service.GetDepartmentByID(id);// await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            _service.DeleteDepartment(id);
            return NoContent();
        }
        [HttpGet("Pagination")]
        public async Task<ActionResult<IEnumerable<DepartmentPagnationDto>>> GetWithPagination([FromQuery] int page = 1, [FromQuery] int pageSize = 5)
        {
            return Ok(_service.GetAllWithPagnation(page, pageSize));
        }
    }
}
