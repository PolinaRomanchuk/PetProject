using Data.SQL.Interfaces;
using Data.SQL.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.SQL.Repositories
{
    public abstract class BaseRepository<DbModelType>
        : IBaseRepository<DbModelType> where DbModelType : BaseModel
    {
        protected WebContext _webContext;
        protected DbSet<DbModelType> _dbSet;

        public BaseRepository(WebContext webContext)
        {
            _webContext = webContext;
            _dbSet = webContext.Set<DbModelType>();
        }

        public DbModelType Add(DbModelType model)
        {
            _dbSet.Add(model);
            _webContext.SaveChanges();
            return model;
        }

        public void Update(DbModelType model)
        {
            _dbSet.Update(model);
            _webContext.SaveChanges();
        }

        public bool Any()
            => _dbSet.Any();

        public int Count()
            => _dbSet.Count();

        public DbModelType Get(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<DbModelType> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Remove(int id)
        {
            _dbSet.Remove(Get(id));
            _webContext.SaveChanges();
        }

    }
}
