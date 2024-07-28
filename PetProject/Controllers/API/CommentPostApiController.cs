using Microsoft.AspNetCore.Mvc;
using PetProject.Services;

namespace PetProject.Controllers.API
{
    [ApiController]
    [Route("api/commentPost")]
    public class CommentPostApiController : Controller
    {
        private IUserPostService _userPostService;
        private ICommentService _commentService;

        public CommentPostApiController (IUserPostService userPostService, ICommentService commentService)
        {
            _userPostService = userPostService;
            _commentService = commentService;
        }

        [Route("CreateNewComment")]
        public void AddNewComment([FromForm] int commentAuthor, [FromForm] string commentText, [FromForm] int currentPost)
        {
            _commentService.AddNewComment(commentAuthor, commentText, currentPost);
        }
    }
}
