using Day4WebApiWithDataDemo.Repositories;

namespace Day4WebApiWithDataDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReposDepartmentsController : ControllerBase
    {
        // private readonly AppDbContext _context;
        //public ReposDepartmentsController(AppDbContext context)
        //{
        //    _context = context;
        //}
        private readonly DepartmentRepository _repo;
        public ReposDepartmentsController(DepartmentRepository repo)
        {
            _repo = repo;
        }
        // GET: api/ReposDepartments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentGetDto>>> GetDepartments()
        {
            // return await _context.Departments.ToListAsync();
            return _repo.GetDepartments().ToList();
        }
        // GET: api/ReposDepartments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentGetDto>> GetDepartment(int id)
        {
            //var department = await _context.Departments.FindAsync(id);
            var department = _repo.GetDepartment(id);

            if (department == null)
            {
                return NotFound();
            }
            return department;
        }
        // PUT: api/ReposDepartments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, Department department)
        {
            if (id != department.DepartmentId)
            {
                return BadRequest();
            }
            _repo.EditDepartment(id, department);
            //_context.Entry(department).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!DepartmentExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
            return NoContent();
        }
        // POST: api/ReposDepartments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department department)
        {
            //_context.Departments.Add(department);
            //await _context.SaveChangesAsync();
            if (!ModelState.IsValid) return BadRequest(department);

            _repo.AddDepartment(department);
            //_repo.AddDepartment(department);
            //_repo.AddDepartment(department);
            //_repo.complete();
            return CreatedAtAction("GetDepartment", new { id = department.DepartmentId }, department);
        }
        // DELETE: api/ReposDepartments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            //var department = await _context.Departments.FindAsync(id);
            var department = _repo.GetDepartment(id);
            if (department == null)
            {
                return NotFound();
            }
            _repo.DeleteDepartment(id);
            //_context.Departments.Remove(department);
            //await _context.SaveChangesAsync();
            return NoContent();
        }
        //private bool DepartmentExists(int id)
        //{
        //   // return _context.Departments.Any(e => e.DepartmentId == id);
        //}
    }
}
