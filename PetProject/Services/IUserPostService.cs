using PetProject.Models;

namespace PetProject.Services
{
    public interface IUserPostService
    {
        void AddNewPost(IFormFile file, int id, string description);
        List<PostViewModel> GetPostsModels(int id);
    }
}