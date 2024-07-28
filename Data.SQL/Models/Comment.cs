namespace Data.SQL.Models
{
    public class Comment : BaseModel
    {
        public virtual User CommentAuthor { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        public int CommentCountOfLikes { get; set; }
        public virtual Post CommentedPost { get; set; }
    }
}
