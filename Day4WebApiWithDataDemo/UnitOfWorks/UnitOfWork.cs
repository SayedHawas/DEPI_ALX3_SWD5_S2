namespace Day4WebApiWithDataDemo.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IRepository<Department> DepartmentRepository { get; }
        public IRepository<Employee> EmployeeRepository { get; }
        public IRepository<Client> ClientRepository { get; }


        public UnitOfWork(AppDbContext context,
            IRepository<Department> departmentRepository,
            IRepository<Employee> employeeRepository,
            IRepository<Client> clientRepository)
        {
            _context = context;
            //DepartmentRepository = new Repository<Department>(_context);
            //EmployeeRepository = new Repository<Employee>(_context);
            DepartmentRepository = departmentRepository; //?? throw new ArgumentNullException(nameof(departmentRepository));
            EmployeeRepository = employeeRepository;//?? throw new ArgumentNullException(nameof(employeeRepository));
            ClientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        }
        public int Complete()
        {
            var rows = _context.SaveChanges();
            _context.ChangeTracker.Clear();//.State = EntityState.Detached;
            return rows;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
