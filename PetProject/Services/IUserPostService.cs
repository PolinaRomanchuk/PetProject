namespace PetProject.Services
{
    public interface IUserPostService
    {
        void AddNewPost(IFormFile file, int id, string description);
    }
}