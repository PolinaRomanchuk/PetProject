using Microsoft.AspNetCore.Mvc;

namespace PetProject.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }


    }
}
