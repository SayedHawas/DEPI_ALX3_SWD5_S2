using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Day8MVCDemo.Repostories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _appDbContext;
        public Repository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        public void Add(T entity)
        {
            _appDbContext.Set<T>().Add(entity);
        }
        public int Counter()
        {
            return _appDbContext.Set<T>().Count();
        }
        public void Delete(int? id)
        {
            T entity = _appDbContext.Set<T>().Find(id);
            _appDbContext.Set<T>().Remove(entity);
        }
        public IEnumerable<T> GetAll()
        {
            return _appDbContext.Set<T>().AsNoTracking().ToList();
        }
        public T GetById(int? id)
        {
            return _appDbContext.Set<T>().Find(id);
        }
        public IEnumerable<T> GetWithPagination(int page = 1, int pageSize = 6)
        {
            var totalCount = _appDbContext.Set<T>().Count();
            var totalPage = (int)Math.Ceiling((double)totalCount / pageSize);
            var list = _appDbContext.Set<T>().AsNoTracking().Skip((page - 1) * pageSize).Take(pageSize);
            return list.ToList();
        }
        public void Update(T entity)
        {
            _appDbContext.Entry(entity).State = EntityState.Modified;
        }
        public IEnumerable<T> Search(Expression<Func<T, bool>> predicate)
        {
            return _appDbContext.Set<T>().Where(predicate).AsNoTracking().ToList();
            //Search (c=>c.Id>6)
        }

        public IEnumerable<T> GetAllIncluding(params string[] includes) //("Employees"," Orders")
        {
            IQueryable<T> query = _appDbContext.Set<T>().AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.AsNoTracking().ToList();
        }
        //public Repository()
        //{
        //    Repostories.Repository<Product> p = new Repository<Product>();
        //   var pp=  p.Search(p => p.Price > 50000);
        //    var ppp = p.Search(p => p.Name.Contains("a"));
        //    var ppPP = p.Search(p => p.ProductId > 5);
        //}
        public int GetMaxId()
        {
            var keyName = _appDbContext.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.Select(x => x.Name).Single();
            // Use EF Core's Find method instead of reflection
            return _appDbContext.Set<T>().Max(e => EF.Property<int>(e, keyName));

        }
    }
}

//Search(Expression<Func>

//Product Price >50000

//Product ProductId >6

//ProductName Contins (wood)


//Func (Product p, Prdictate<bool> )
/*
public IEnumerable<Product> Search(Expression<Func<Products, bool>> predicate)
{
    return _appDbContext.Set<T>().Where(predicate).AsNoTracking().ToList();

    DB.Set<Products>.where(p=>p.Price >50000)
    //Search (c=>c.Id>6)
}
*/