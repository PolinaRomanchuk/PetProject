using Data.SQL.Models;

namespace Data.SQL.Interfaces
{
    public interface IUserProfileRepository : IBaseRepository<UserProfile>
    {
        void UpdatePetNameUserNameAndInfoBioInUserProfile(string petName, string petInfo, int id);
    }
}
