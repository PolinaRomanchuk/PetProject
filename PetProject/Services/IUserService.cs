using Data.SQL.Models;
using PetProject.Models;

namespace PetProject.Services
{
    public interface IUserService 
    {
        User Login(string login, string password);
        public void AddUser (UserViewModel viewModel);
        User GetById(int currentUserId);
        
    }
}
