using Data.SQL.Interfaces;
using Data.SQL.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.SQL.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(WebContext webContext) : base(webContext) { }

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
            return _dbSet.FirstOrDefault(x => x.LoginName == login && x.Password == password);
        }

        public User GetUserWithProfile(int id)
        {
            return _dbSet
                .Include(x => x.Profile)
                .SingleOrDefault(x => x.Id == id);
        }

        public User GetUserWithProfileandPosts(int id)
        {
            return _dbSet
                .Include(x => x.Profile)
                .Include(x => x.Posts)
                .SingleOrDefault(x => x.Id == id);
        }
    }
}
