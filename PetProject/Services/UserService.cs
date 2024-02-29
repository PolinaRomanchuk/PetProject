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

        public void AddUser(UserViewModel viewModel)
        {
            var User = new User
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Password = viewModel.Password,
            };
            _userRepository.Add(User);
        }

        public User GetById(int id)
        {
           return _userRepository.GetById(id);
        }

        public User Login(string login, string password)
        {
            return _userRepository.GetByNameAndPassword(login, password);
        }
    }
}
