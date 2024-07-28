using Data.SQL.Interfaces;
using Data.SQL.Models;
using PetProject.Models;

namespace PetProject.Services
{
    public class CommentService : ICommentService
    {
        private IUserRepository _userRepository;
        private IPostRepository _postRepository;
        private ICommentRepository _commentRepository;
        public CommentService(IUserRepository userRepository, IPostRepository postRepository, ICommentRepository commentRepository)
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
            _commentRepository = commentRepository;
        }

        public void AddNewComment(int commentAuthor, string commentText, int currentPost)
        {
            var user = _userRepository.Get(commentAuthor);
            var post = _postRepository.Get(currentPost);
            var newComment = new Comment
            {
                CommentAuthor = user,
                CommentCountOfLikes = 0,
                CommentDate = new DateTime().Date.ToLocalTime(),
                CommentText = commentText,
                CommentedPost = post,
            };
            _commentRepository.Add(newComment);
        }

        public List<CommentViewModel> SqlModelToViewModel(List<Comment> comment)
        {
            return comment.Select(x => new CommentViewModel
            {
                CommentAuthor = x.CommentAuthor.Id,
                CommentText = x.CommentText,
                CommentCountOfLikes = x.CommentCountOfLikes,
                CommentDate = x.CommentDate,
            }).ToList();
        }
    }
}