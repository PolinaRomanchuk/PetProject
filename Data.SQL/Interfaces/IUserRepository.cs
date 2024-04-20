using Data.SQL.Models;

namespace Data.SQL.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetById(int id);
        public User Add(User user);
        User GetByNameAndPassword(string login, string password);

        User GetUserWithProfile(int id);

        User GetUserWithProfileandPosts(int id);
    }
}
