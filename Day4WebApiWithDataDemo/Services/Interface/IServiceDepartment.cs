namespace Day4WebApiWithDataDemo.Services.Interface
{
    public interface IServiceDepartment
    {
        IEnumerable<DepartmentGetDto> GetDepartments();
        DepartmentGetDto GetDepartmentByID(int id);
        DepartmentGetDto GetDepartmentByIDWithIncluding(int id, string including);
        void AddDepartment(DepartmentPostDto department);
        void UpdateDepartment(DepartmentPutDto department);
        void DeleteDepartment(int id);
        int GetDepartmentCounter();
        IEnumerable<DepartmentPagnationDto> GetAllWithPagnation(int page = 1, int pageSize = 10);
    }
}
