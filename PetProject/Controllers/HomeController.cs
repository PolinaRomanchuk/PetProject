using Microsoft.AspNetCore.Mvc;

namespace PetProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
