using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using PetProject.Models;
using PetProject.Services;

namespace PetProject.Controllers.API
{
    [ApiController]
    [Route("/api/user")]
    public class UserApiController : Controller
    {
        private IUserService _userService;

        public UserApiController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("CreateNewUser")]
        public void CreateNewUser(string loginName, string password, string email)
        {
            _userService.CreateUser(loginName, password, email);
        }
    }
}
