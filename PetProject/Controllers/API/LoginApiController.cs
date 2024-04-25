using Data.SQL.Models;
using Microsoft.AspNetCore.Mvc;
using PetProject.Services;

namespace PetProject.Controllers.API
{
    [ApiController]
    [Route("/api/login")]
    public class LoginApiController : Controller
    {
        private IUserService _userService;

        public LoginApiController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("GetUserId")]
        public int GetUserId(string login, string password)
        {
            var viewModel = _userService.Login(login, password);

            return viewModel.Id;
        }

        [Route("GetUser")]
        public User GetUser(int id)
        {
            var viewModel = _userService.GetById(id);

            return viewModel;
        }
    }
}
