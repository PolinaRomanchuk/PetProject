using PetProject.Models;

namespace PetProject.Services
{
    public interface IUserProfileService
    {
        UserProfileViewModel GetUserProfileById(int id);
        void UpdateUserProfile(string petName, string petInfo, int id);
        void UpdateUserProfileAvatar(IFormFile formFile, int id);
    }
}