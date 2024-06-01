using Data.SQL.Interfaces;
using Data.SQL.Models;
using PetProject.Models;

namespace PetProject.Services
{
    public class UserProfileService : IUserProfileService
    {
        private IUserRepository _userRepository;
        private IAuthService _authService;
        private IUserProfileRepository _userProfileRepository;
        private IWebHostEnvironment _webHostEnvironment;

        public UserProfileService(IUserRepository userRepository, IAuthService authService, IUserProfileRepository userProfileRepository, IWebHostEnvironment webHostEnvironment)
        {
            _userRepository = userRepository;
            _authService = authService;
            _userProfileRepository = userProfileRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public UserProfileViewModel GetUserProfileById(int id)
        {
            var user = _userRepository.GetUserWithProfileandPosts(id);

            return new UserProfileViewModel
            {
                Id = user.Id,
                PetName = user.Profile.PetName,
                InfoBio = user.Profile.InfoBio,
                FollowersCount = user.Profile.FollowersCount,
                FollowingCount = user.Profile.FollowingCount,
                PostsCount = user.Posts.Count,
                PhotoUrl = user.Profile.ProfilePhotoUrl,
                Posts = user.Posts.Select(x => x.ImageUrl).ToList(),
            };
        }

        public void UpdateUserProfileAvatar(IFormFile formFile, int id)
        {
            var user = _userProfileRepository.Get(id);
            if (formFile != null)
            {
                var ext = Path.GetExtension(formFile.FileName);
                var fileName = $"avatar-{user.Id}{ext}";
                if (!File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                var path = Path.Combine(
                    _webHostEnvironment.WebRootPath,
                    "images",
                    "avatars",
                    fileName);

                using (var fs = File.Create(path))
                {
                    formFile.CopyTo(fs);
                }
                user.ProfilePhotoUrl = $"https://localhost:7074/images/avatars/{fileName}";
                _userProfileRepository.Update(user);
            }
        }

        public void UpdateUserProfile(string petName, string petInfo, int id)
        {
            _userProfileRepository.UpdatePetNameUserNameAndInfoBioInUserProfile(petName, petInfo, id);
        }
    }
}
