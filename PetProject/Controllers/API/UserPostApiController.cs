using Microsoft.AspNetCore.Mvc;
using PetProject.Services;

namespace PetProject.Controllers.API
{
    [ApiController]
    [Route("api/userPost")]
    public class UserPostApiController : Controller
    {
        private IUserPostService _userPostService;

        public UserPostApiController(IUserPostService userPostService)
        {
            _userPostService = userPostService;
        }

        [Route("AddNewPost")]
        public void AddNewPostImage([FromForm] IFormFile file, [FromForm] int id, [FromForm] string? description)
        {
            _userPostService.AddNewPost(file, id, description);
        }
    }
}
