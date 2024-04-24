using PetProject.Models;

namespace PetProject.Services
{
    public interface IUserProfileService
    {
        UserProfileViewModel GetUserProfile();
        UserProfileViewModel GetUserProfileById(int id);
        void UpdateUserProfileAvatar(UserProfileViewModel viewModel);
        void UpdateUserProfile(int id, string newPetName, string newInfoBio);
    }
}