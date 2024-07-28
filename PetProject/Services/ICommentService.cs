using Data.SQL.Models;
using PetProject.Models;

namespace PetProject.Services
{
    public interface ICommentService
    {
        void AddNewComment(int commentAuthor, string commentText, int currentPost);
        List<CommentViewModel> SqlModelToViewModel(List<Comment> comment);
    }
}