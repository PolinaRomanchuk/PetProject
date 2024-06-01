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
            return _userProfileService.GetUserProfileById(id);
        }

        [Route("UpdateProfile")]
        public void UpdateUserProfile(string petName, string? petInfo, int id)
        {
            _userProfileService.UpdateUserProfile(petName, petInfo, id);
        }

        [Route("UpdateAvatar")]
        public void UpdateAvatar([FromForm] IFormFile file, [FromForm] int id)
        {
            _userProfileService.UpdateUserProfileAvatar(file, id);
        }
    }
}
