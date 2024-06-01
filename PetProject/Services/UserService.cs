using Data.SQL.Interfaces;
using Data.SQL.Models;
using PetProject.Models;

namespace PetProject.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateUser(string loginName, string password, string email)
        {
            var User = new User
            {
                LoginName = loginName,
                Password = password,
                Email = email,
            };
            _userRepository.Add(User);
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public User Login(string login, string password)
        {
            return _userRepository.GetUserByNameAndPassword(login, password);
        }
    }
}
