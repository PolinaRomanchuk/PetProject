using Data.SQL.Interfaces;
using Data.SQL.Models;

namespace PetProject.Services
{
    public class UserPostService : IUserPostService
    {
        private IUserRepository _userRepository;
        private IPostRepository _postRepository;
        private IWebHostEnvironment _webHostEnvironment;

        public UserPostService(IUserRepository userRepository, IPostRepository postRepository, IWebHostEnvironment webHostEnvironment)
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
            _webHostEnvironment = webHostEnvironment;
        }


        public void AddNewPost(IFormFile file, int id, string description)
        {
            var user = _userRepository.Get(id);
            var newPost = new Post
            {
                ImageUrl = "Temp",
                DateOfPublication = new DateTime(),
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
    }
}
