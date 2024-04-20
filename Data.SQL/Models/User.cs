namespace Data.SQL.Models
{
    public class User: BaseModel
    {
        public required string LoginName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

        public virtual UserProfile? Profile { get; set; }

        public virtual List<Post>? Posts { get; set;}
    }
}
