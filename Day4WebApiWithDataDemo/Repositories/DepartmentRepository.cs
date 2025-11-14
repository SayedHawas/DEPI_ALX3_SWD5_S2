namespace Day4WebApiWithDataDemo.Repositories
{
    public class DepartmentRepository
    {
        //DI Entity frameWork
        private readonly AppDbContext _db;
        public DepartmentRepository(AppDbContext db)
        {
            this._db = db;
        }
        //CRUD 
        //Get ALL
        public IEnumerable<DepartmentGetDto> GetDepartments()
        {
            var list = _db.Departments.Include("Employees").AsNoTracking().ToList();
            List<DepartmentGetDto> result = new List<DepartmentGetDto>();
            foreach (var item in list)
            {
                result.Add(new DepartmentGetDto
                {
                    DepartmentId = item.DepartmentId,
                    Name = item.Name,
                    Description = item.Description,
                    EmployeeCount = item.Employees.Count,
                    EmployeesName = item.Employees.Select(e => e.Name).ToList()
                });
            }
            return result;
        }
        //Get By ID 
        public DepartmentGetDto GetDepartment(int id)
        {
            var department = _db.Departments.Include("Employees").FirstOrDefault(d => d.DepartmentId == id);

            DepartmentGetDto result = new DepartmentGetDto()
            {
                DepartmentId = department.DepartmentId,
                Name = department.Name,
                Description = department.Description,
                EmployeeCount = department.Employees.Count,
                EmployeesName = department.Employees.Select(e => e.Name).ToList()
            };
            return result;
        }
        //Create
        public void AddDepartment(Department department)
        {
            _db.Departments.Add(department);
            _db.SaveChanges();
        }
        //Edit 
        public void EditDepartment(int id, Department newDepartment)
        {
            var selectDepartment = _db.Departments.Find(id);
            selectDepartment.Name = newDepartment.Name;
            selectDepartment.Description = newDepartment.Description;
            _db.SaveChanges();
        }
        //Delete 
        public void DeleteDepartment(int id)
        {
            var selectDepartment = _db.Departments.Find(id);
            _db.Departments.Remove(selectDepartment);
            _db.SaveChanges();
        }

        //public void complete()
        //{
        //    _db.SaveChanges();
        //}
    }
}
