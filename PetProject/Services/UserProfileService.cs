using Data.SQL.Interfaces;
using Data.SQL.Models;
using Microsoft.Extensions.Hosting;
using PetProject.Models;

namespace PetProject.Services
{
    public class UserProfileService: IUserProfileService
    {
        private IUserRepository _userRepository;
        private IAuthService _authService;

        public UserProfileService(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }
        public User GetCurrentUserProfile()
        {
            var userId = _authService.GetUser().Id;
            var userWithProfile = _userRepository.GetUserWithProfileandPosts(userId);
            return userWithProfile;
        }

        public UserProfileViewModel GetUserProfile()
        {
            var user = GetCurrentUserProfile();

            return new UserProfileViewModel
            {
                Id = user.Id,
                PetName = user.Profile.PetName,
                InfoBio = user.Profile.InfoBio,
                FollowersCount = user.Profile.FollowersCount,
                FollowingCount = user.Profile.FollowingCount,
                PostsCount = user.Profile.PostsCount,
                Posts = user.Posts.Select(x => x.ImageUrl).ToList(),
            };
        }
    }
}
