using Data.SQL.Models;

namespace PetProject.Services
{
    public interface IUserService
    {
        User Login(string login, string password);
        User GetUserById(int currentUserId);
        public void CreateUser(string loginName, string email, string password);
    }
}
