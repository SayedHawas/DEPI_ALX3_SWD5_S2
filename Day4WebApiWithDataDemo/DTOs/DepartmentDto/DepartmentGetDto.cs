namespace Day4WebApiWithDataDemo.DTOs.DepartmentDto
{
    public class DepartmentGetDto
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        //Additional Fields 
        public int EmployeeCount { get; set; }
        public List<string> EmployeesName { get; set; }
    }
}
