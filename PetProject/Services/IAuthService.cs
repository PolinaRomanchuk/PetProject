using Data.SQL.Models;

namespace PetProject.Services
{
    public interface IAuthService
    {
        User GetUser();
    }
}