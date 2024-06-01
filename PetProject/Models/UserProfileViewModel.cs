namespace PetProject.Models
{
    public class UserProfileViewModel
    {
        public int Id { get; set; }
        public string? PhotoUrl { get; set; }
        public IFormFile? ImgUrlFile { get; set; }
        public string PetName { get; set; }
        public string? InfoBio { get; set; }
        public int FollowersCount { get; set; }
        public int FollowingCount { get; set; }
        public int PostsCount { get; set; }
        public List<string>? Posts { get; set; }

    }
}
