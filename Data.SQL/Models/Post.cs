namespace Data.SQL.Models
{
    public class Post : BaseModel
    {
        public string ImageUrl { get; set; }
        public DateTime DateOfPublication { get; set; }
        public string? Description { get; set; }
        public int CountOfLikes { get; set; }
        public virtual User Author { get; set; }
    }
}
