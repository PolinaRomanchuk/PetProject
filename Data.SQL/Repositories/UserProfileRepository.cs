using Data.SQL.Interfaces;
using Data.SQL.Models;

namespace Data.SQL.Repositories
{
    public class UserProfileRepository: BaseRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(WebContext webContext) : base(webContext) { }

        public void UpdatePetNameAndInfoBioInUserProfile(int id, string newPetName, string newInfoBio)
        {
            var user = _dbSet.SingleOrDefault(x => x.Id == id);
            user.InfoBio = newInfoBio;
            user.PetName = newPetName;
            _webContext.SaveChanges();
        }
    }
}
