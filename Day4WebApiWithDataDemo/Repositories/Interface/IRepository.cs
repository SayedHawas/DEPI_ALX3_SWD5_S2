using System.Linq.Expressions;

namespace Day4WebApiWithDataDemo.Repositories.Interface
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetByID(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        int RowCount();
        IEnumerable<T> GetAllIncluding(params string[] including);
        IEnumerable<T> GetAllWithPagnation(int page = 1, int pageSize = 10);
        T GetByIDWithIncluding(int id, string including);

        //("Employees "," Clients","...")
        // _db.departments.including("Employees").
        //                including("Client").tolist()

    }
}
