using Day4WebApiWithDataDemo.UnitOfWorks;

namespace Day4WebApiWithDataDemo.Services.Impelement
{
    public class ServiceDepartment : IServiceDepartment
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServiceDepartment(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<DepartmentGetDto> GetDepartments()
        {
            //var list = _unitOfWork.DepartmentRepository.GetAll();
            var list = _unitOfWork.DepartmentRepository.GetAllIncluding("Employees");
            List<DepartmentGetDto> result = new List<DepartmentGetDto>();
            foreach (var department in list)
            {
                result.Add(new DepartmentGetDto
                {
                    DepartmentId = department.DepartmentId,
                    Name = department.Name,
                    Description = department.Description,
                    EmployeeCount = department.Employees.Count,
                    EmployeesName = department.Employees.Select(e => e.Name).ToList()
                });
            }
            return result;
        }
        public DepartmentGetDto GetDepartmentByID(int id)
        {
            var department = _unitOfWork.DepartmentRepository.GetByID(id);
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
        public DepartmentGetDto GetDepartmentByIDWithIncluding(int id, string including)
        {
            var department = _unitOfWork.DepartmentRepository.GetByIDWithIncluding(id, including);
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
        public void AddDepartment(DepartmentPostDto department)
        {
            Department departmentAdd = new Department();
            departmentAdd.Name = department.Name;
            departmentAdd.Description = department.Description;
            _unitOfWork.DepartmentRepository.Add(departmentAdd);
            _unitOfWork.Complete();
        }
        public void UpdateDepartment(DepartmentPutDto department)
        {
            var selectDepartment = _unitOfWork.DepartmentRepository.GetByID(department.DepartmentId);
            selectDepartment.Name = department.Name;
            selectDepartment.Description = department.Description;

            _unitOfWork.DepartmentRepository.Update(selectDepartment);
            _unitOfWork.Complete();
        }
        public void DeleteDepartment(int id)
        {
            var department = _unitOfWork.DepartmentRepository.GetByID(id);
            if (department != null)
            {
                _unitOfWork.DepartmentRepository.Delete(id);
                _unitOfWork.Complete();
            }
        }
        public int GetDepartmentCounter()
        {
            return _unitOfWork.DepartmentRepository.RowCount();
        }
        public IEnumerable<DepartmentPagnationDto> GetAllWithPagnation(int page = 1, int pageSize = 10)
        {
            var Departments = _unitOfWork.DepartmentRepository.GetAllWithPagnation(page, pageSize);

            List<DepartmentPagnationDto> result = new List<DepartmentPagnationDto>();
            foreach (var department in Departments)
            {
                result.Add(new DepartmentPagnationDto
                {
                    DepartmentId = department.DepartmentId,
                    Name = department.Name,
                    Description = department.Description
                });
            }
            //Pagination
            return result;
        }
    }
}
