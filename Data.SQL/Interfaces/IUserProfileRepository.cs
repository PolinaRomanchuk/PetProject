﻿using Data.SQL.Models;

namespace Data.SQL.Interfaces
{
    public interface IUserProfileRepository : IBaseRepository<UserProfile>
    {
        void UpdatePetNameAndInfoBioInUserProfile(int id, string newPetName, string newInfoBio);
    }
}