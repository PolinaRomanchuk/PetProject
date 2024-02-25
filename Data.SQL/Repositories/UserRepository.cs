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
    }
}
