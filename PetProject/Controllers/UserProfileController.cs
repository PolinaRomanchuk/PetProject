using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetProject.Models;
using PetProject.Services;

namespace PetProject.Controllers
{
    public class UserProfileController : Controller
    {
        private IUserService _userService;
        private IUserProfileService _userProfileService;
        public UserProfileController(IUserService userService, IUserProfileService userProfileService)
        {
            _userService = userService;
            _userProfileService = userProfileService;
        }

        [Authorize]
        public IActionResult OpenProfile()
        {
            var view = _userProfileService.GetUserProfile();
            return View(view);
        }

        [HttpGet]
        public IActionResult UpdateProfile(int id) 
        {
            var profile = _userProfileService.GetUserProfileById(id);
            return View(profile);
        }

        [HttpPost]
        public IActionResult UpdateProfile(UserProfileViewModel viewModel)
        {
            _userProfileService.UpdateUserProfile(viewModel.Id, viewModel.PetName, viewModel.InfoBio);
            _userProfileService.UpdateUserProfileAvatar(viewModel);
            return RedirectToAction("OpenProfile");
        }
        
    }
}
