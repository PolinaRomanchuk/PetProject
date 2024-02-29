using Data.SQL.Models;

namespace Data.SQL.Interfaces
{
    public interface IUserRepository
    {
        User GetById(int id);
        public User Add(User user);
        User GetByNameAndPassword(string login, string password);
    }
}
