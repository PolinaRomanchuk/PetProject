using Data.SQL.Interfaces;
using Data.SQL.Models;
using PetProject.Models;

namespace PetProject.Services
{
    public class UserPostService : IUserPostService
    {
        private IUserRepository _userRepository;
        private IPostRepository _postRepository;
        private ICommentRepository _commentRepository;
        private IWebHostEnvironment _webHostEnvironment;
        private ICommentService _commentService;

        public UserPostService(IUserRepository userRepository, IPostRepository postRepository, IWebHostEnvironment webHostEnvironment, ICommentRepository commentRepository, ICommentService commentService)
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
            _webHostEnvironment = webHostEnvironment;
            _commentRepository = commentRepository;
            _commentService = commentService;
        }


        public void AddNewPost(IFormFile file, int id, string description)
        {
            var user = _userRepository.Get(id);
            var newPost = new Post
            {
                ImageUrl = "Temp",
                DateOfPublication = DateTime.Now.ToLocalTime(),
                Author = user,
                CountOfLikes = 0,
                Description = description,
            };
            _postRepository.Add(newPost);
            if (file != null)
            {
                var ext = Path.GetExtension(file.FileName);
                var name = Path.GetFileName(file.FileName);
                var fileName = $"post-{name}{ext}";

                var path = Path.Combine(
                    _webHostEnvironment.WebRootPath,
                    "images",
                    "posts",
                    fileName);

                using (var fs = File.Create(path))
                {
                    file.CopyTo(fs);
                }
                newPost.ImageUrl = $"https://localhost:7074/images/posts/{fileName}";
                _postRepository.Update(newPost);
            }
        }
        public List<PostViewModel> GetPostsModels(int id)
        {
            var user = _userRepository.Get(id);
            var posts = _postRepository.GetAll().Where(x => x.Author.Id == id).ToList();
            var postId = 0;
            var comments = _commentRepository.GetAll().ToList();
          
            return posts.Select(x => new PostViewModel
            {
                Id = x.Id = postId,
                CountOfLikes = x.CountOfLikes,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                DateOfPublication = x.DateOfPublication,
                Comments = _commentService.SqlModelToViewModel(comments.Where(x => x.CommentedPost.Id == postId).ToList()),
            }).ToList();
        }
    }
}


