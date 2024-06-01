﻿using PetProject.Models;

namespace PetProject.Services
{
    public interface IUserProfileService
    {
        UserProfileViewModel GetUserProfile();
        UserProfileViewModel GetUserProfileById(int id);
        void UpdateUserProfileAvatar(UserProfileViewModel viewModel);
        void UpdateUserProfile(int id, string newPetName, string newInfoBio);
        void UpdateUserProfile(string petName, string petInfo, int id);
        void UpdateUserProfileAvatar(IFormFile formFile, int id);
    }
}