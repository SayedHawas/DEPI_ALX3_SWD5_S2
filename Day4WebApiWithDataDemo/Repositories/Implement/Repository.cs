using System.Linq.Expressions;
namespace Day4WebApiWithDataDemo.Repositories.Implement
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _db;
        public Repository(AppDbContext db)
        {
            this._db = db;
        }
        public void Add(T entity)
        {
            _db.Set<T>().Add(entity);
            // _db.SaveChanges();

        }
        public void Delete(int id)
        {
            T entity = _db.Set<T>().Find(id);
            _db.Set<T>().Remove(entity);
            // _db.SaveChanges();
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _db.Set<T>().Where(predicate).AsNoTracking().ToList();
        }
        public IEnumerable<T> GetAll()
        {
            return _db.Set<T>().AsNoTracking().ToList();
        }
        public IEnumerable<T> GetAllIncluding(params string[] including)
        {
            IQueryable<T> query = _db.Set<T>().AsQueryable();
            foreach (var include in including)
            {
                query = query.Include(include);
            }
            return query.AsNoTracking().ToList();
            /*
             query = _appDbContext.department.Include("Employee").AsNoTracking.Tolist() 
            */
        }
        public IEnumerable<T> GetAllWithPagnation(int page = 1, int pageSize = 10)
        {
            var totalCount = _db.Set<T>().Count();
            var totalPage = (int)Math.Ceiling((double)totalCount / pageSize);

            IQueryable<T> list = _db.Set<T>().AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
            //Pagination
            return list;
        }
        public T GetByID(int id)
        {
            // return _db.Set<T>().Find(id);
            var keyName = _db.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.Select(x => x.Name).Single();
            // Use EF Core's Find method instead of reflection
            T entity = _db.Set<T>().FirstOrDefault(e => EF.Property<int>(e, keyName) == id);
            return entity;
        }
        public T GetByIDWithIncluding(int id, string including)
        {
            // return _db.Set<T>().Find(id);
            var keyName = _db.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.Select(x => x.Name).Single();
            // Use EF Core's Find method instead of reflection
            T entity = _db.Set<T>().Include(including).FirstOrDefault(e => EF.Property<int>(e, keyName) == id);
            return entity;
        }
        public int RowCount()
        {
            return _db.Set<T>().Count();
        }
        public void Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            // _db.SaveChanges();
            //var keyName = _db.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.Select(x => x.Name).Single();
            //// Use EF Core's Find method instead of reflection
            //T entity =  _db.Set<T>().FirstOrDefault(e => EF.Property<int>(e, keyName) == id);
            //_db.Entry(entity).State = EntityState.Modified;
            //_db.SaveChanges();
        }
    }
}
