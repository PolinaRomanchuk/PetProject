using Data.SQL.Models;
using Microsoft.AspNetCore.Mvc;
using PetProject.Models;
using PetProject.Services;

namespace PetProject.Controllers.API
{
    [ApiController]
    [Route("/api/user")]
    public class UserApiController : Controller
    {
        private IUserService _userService;
        private IUserProfileService _userProfileService;

        public UserApiController(IUserService userService, IUserProfileService userProfileService)
        {
            _userService = userService;
            _userProfileService = userProfileService;
        }

        [Route("CreateNewUser")]
        public void CreateNewUser(string loginName, string password, string email)
        {
            _userService.CreateUser(loginName, password, email);
        }

        [Route("OpenUserProfile")]
        public UserProfileViewModel OpenProfile(int id)
        {
            var c= _userProfileService.GetUserProfileById(id);
            return c;
        }

        [Route("GetUserPosts")]
        public UserProfileViewModel GetUserPosts(int id)
        {
            var c = _userProfileService.GetUserProfileById(id);
            return c;
        }

    }
}
