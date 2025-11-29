using System.Linq.Expressions;

namespace Day8MVCDemo.Repostories
{
    public interface IRepository<T> where T : class
    {
        //CRUD 
        IEnumerable<T> GetAll();
        T GetById(int? id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int? id);
        int Counter();
        IEnumerable<T> GetAllIncluding(params string[] includes);
        IEnumerable<T> Search(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetWithPagination(int page = 1, int pageSize = 6);
        int GetMaxId();
    }
}
