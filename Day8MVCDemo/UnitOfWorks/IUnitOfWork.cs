namespace Day8MVCDemo.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Category> CategoriesRepository { get; }
        IRepository<Product> ProductsRepository { get; }
        IRepository<Department> DepartmentsRepository { get; }
        //SaveChange
        int Complete();
    }
}
