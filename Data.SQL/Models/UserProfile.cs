namespace Data.SQL.Models
{
    public class UserProfile : BaseModel
    {
        public string? ProfilePhotoUrl { get; set; }
        public required string PetName { get; set; }
        public string? InfoBio { get; set; }
        public int FollowersCount { get; set; }
        public int FollowingCount {  get; set; }
        public int PostsCount { get; set; }
        public virtual User UserData { get; set; }
    }
}
