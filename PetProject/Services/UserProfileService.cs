﻿using Data.SQL.Interfaces;
using Data.SQL.Models;
using PetProject.Models;

namespace PetProject.Services
{
    public class UserProfileService: IUserProfileService
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
                PostsCount = user.Posts.Count,
                PhotoUrl = user.Profile.ProfilePhotoUrl,
                Posts = user.Posts.Select(x => x.ImageUrl).ToList(),
            };
        }

        public UserProfileViewModel GetUserProfileById(int id)
        {
            var user = _userRepository.GetUserWithProfile(id);

            return new UserProfileViewModel
            {
                Id = user.Id,
                PetName = user.Profile.PetName,
                InfoBio = user.Profile.InfoBio,
                PhotoUrl = user.Profile.ProfilePhotoUrl,
            };
        }

        public void UpdateUserProfile(int id, string newPetName, string newInfoBio)
        {
            _userProfileRepository.UpdatePetNameAndInfoBioInUserProfile(id, newPetName, newInfoBio);
        }

        public void UpdateUserProfileAvatar(UserProfileViewModel viewModel)
        {
            var user = _userProfileRepository.Get(viewModel.Id);
            if (viewModel.ImgUrlFile != null) 
            {
                var ext = Path.GetExtension(viewModel.ImgUrlFile.FileName);
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
                    viewModel.ImgUrlFile.CopyTo(fs);
                }

                user.ProfilePhotoUrl = $"/images/avatars/{fileName}";
                _userProfileRepository.Update(user);
            }
        }
    }
}