namespace Day4WebApiWithDataDemo.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Department> DepartmentRepository { get; }
        IRepository<Employee> EmployeeRepository { get; }
        IRepository<Client> ClientRepository { get; }
        int Complete();
    }
}
