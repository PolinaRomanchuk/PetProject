using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PetProject.Models;
using PetProject.Services;
using System.Security.Claims;

namespace PetProject.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;
        private IUserProfileService _userProfileService;
        public UserController(IUserService userService, IUserProfileService userProfileService)
        {
            _userService = userService;
            _userProfileService = userProfileService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddUser(UserViewModel viewModel)
        {
            _userService.AddUser(viewModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var user = _userService.Login(viewModel.Login, viewModel.Password);

            if (user == null)
            {
                ModelState.AddModelError(nameof(viewModel.Login), "Неверный пароль или (и) логин");

                return View(viewModel);
            }

            var claims = new List<Claim>() {
                    new Claim(AuthService.AUTH_CLAIMS_ID_NAME, user.Id.ToString()),
                    new Claim("LoginName", user.LoginName),
                    new Claim(ClaimTypes.AuthenticationMethod, AuthService.AUTH_NAME)
                };

            var identity = new ClaimsIdentity(claims, AuthService.AUTH_NAME);

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(principal);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }

       
    }
}
