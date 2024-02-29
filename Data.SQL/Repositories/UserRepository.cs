using Data.SQL.Interfaces;
using Data.SQL.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.SQL.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected WebContext _webContext;
        protected DbSet<User> _dbSet;

        public UserRepository(WebContext webContext)
        {
            _webContext = webContext;
            _dbSet = webContext.Set<User>();
        }

        public User GetById(int id)
        {
            return _dbSet.SingleOrDefault(x => x.Id == id);
        }

        public User Add(User user)
        {
            _dbSet.Add(user);
            _webContext.SaveChanges();
            return user;
        }

        public User GetByNameAndPassword(string login, string password)
        {
            return _dbSet.FirstOrDefault(x => x.Name == login && x.Password == password);
        }
    }
}
