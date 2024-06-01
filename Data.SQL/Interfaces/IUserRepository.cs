using Data.SQL.Models;

namespace Data.SQL.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetUserById(int id);
        public User Add(User user);
        User GetUserByNameAndPassword(string login, string password);
        User GetUserWithProfile(int id);
        User GetUserWithProfileandPosts(int id);
    }
}
