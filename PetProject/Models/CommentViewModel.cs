namespace PetProject.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public int CommentAuthor { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        public int CommentCountOfLikes { get; set; }
    }
}
