namespace Day8MVCDemo.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IRepository<Category> CategoriesRepository { get; }
        public IRepository<Product> ProductsRepository { get; }
        public IRepository<Department> DepartmentsRepository { get; }

        //DI
        public UnitOfWork(AppDbContext context,
                          IRepository<Category> categoriesRepository,
                          IRepository<Product> productsRepository,
                          IRepository<Department> departmentsRepository)
        {
            _context = context;
            CategoriesRepository = categoriesRepository ?? throw new ArgumentNullException(nameof(categoriesRepository));
            ProductsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
            DepartmentsRepository = departmentsRepository;
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
